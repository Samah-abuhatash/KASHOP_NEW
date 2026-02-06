using KASHOP.BLL.serveic.auth;
using KASHOP.BLL.Tokens;
using KASHOP.DAL.DTOS.Request.Auth;
using KASHOP.DAL.DTOS.Request.Token;
using KASHOP.DAL.DTOS.Response.Auth;
using KASHOP.DAL.Moadels;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<Applicationuser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailSender _emailSender;
    private readonly SignInManager<Applicationuser> _signInManager;
    private readonly ITokenService _tokenService;

    public AuthenticationService(UserManager<Applicationuser> userManager, IConfiguration configuration, IEmailSender emailSender, SignInManager<Applicationuser> signInManager,ITokenService tokenService)
    {
        _userManager = userManager;
        _configuration = configuration;
        _emailSender = emailSender;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest)
    {
        try
        {
            var user = registerRequest.Adapt<Applicationuser>();

            var result = await _userManager.CreateAsync(user, registerRequest.Password);

            if (!result.Succeeded)
            {
                return new RegisterResponse
                {
                    messages = "Error",
                    Success = false,
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            await _userManager.AddToRoleAsync(user, "user");
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            token = Uri.EscapeDataString(token);
            var emailurl = $"https://localhost:7293/api/auth/Acount/ConfirmEmail?token={token}&userid={user.Id}";

            await _emailSender.SendEmailAsync(
     user.Email,
     "Welcome",
     $"<h1>Welcome {user.UserName}</h1>" +
     $"<p>Please confirm your email by clicking the link below:</p>" +
     $"<a href='{emailurl}' style='display:inline-block;padding:10px 20px;background-color:#4CAF50;color:white;text-decoration:none;border-radius:5px;'>Confirm your email</a>"
 );

            return new RegisterResponse
            {
                messages = "successful",
                Success = true,
            };
        }
        catch (Exception ex)
        {
            return new RegisterResponse
            {
                messages = "an unexpected  errror",
                Success = false,
                Errors = new List<string> { ex.Message }
            };

        }
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    messages = "Invalid email"
                };
            }
            if (await _userManager.IsLockedOutAsync(user))
            {
                return new LoginResponse()
                {
                    Success = false,
                    messages = "Account is locked , try again Later"
                };
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, true);

            if (result.IsLockedOut)
            {
                return new LoginResponse()
                {
                    Success = false,
                    messages = "Account Locked duo to multiple failed attempts"
                };

            }
            else if (result.IsNotAllowed)
            {
                return new LoginResponse()
                {
                    Success = false,
                    messages = "plz confirm your email;"
                };
            }

            if (!result.Succeeded)
            {
                return new LoginResponse()
                {
                    Success = false,
                    messages = "invaild passworld"
                };
            }

            var accessToken = await _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
          await  _userManager.UpdateAsync(user);


            return new LoginResponse
            {
                Success = true,
                messages = "Login successfully",
                AccessToken = accessToken,
                RefreshToken=refreshToken
            };
        }
        catch (Exception ex)
        {
            return new LoginResponse()
            {
                messages = "an unexpected  errror",
                Success = false,
                Errors = new List<string> { ex.Message }
            };

        }

    }
    public async Task<bool> ConfirmEmailAsync(string token, string userid)
    {
        var user = await _userManager.FindByIdAsync(userid);
        if (user is null) return false;

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (!result.Succeeded)
        {
            return false;
        }

        return true;
    }
    /*
    private async Task<string> GenerateAccessToken(Applicationuser user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
    {

        new Claim("id", user.Id),
        new Claim("userName", user.UserName),
        new Claim("email",user.Email),
         new Claim(ClaimTypes.Role, string.Join(',', roles))
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: authClaims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }*/
    public async Task<ForgotPasswordResponse> RequestPasswordReset(ForgotPasswordRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return new ForgotPasswordResponse
            {
                Success = false,
                messages = "Email Not Found"
            };
        }

        var random = new Random();
        var code = random.Next(1000, 9999).ToString();

        user.CodeResetPassword = code;
        user.PasswordResetCodeExpiry = DateTime.UtcNow.AddMinutes(15);

        await _userManager.UpdateAsync(user);
        await _emailSender.SendEmailAsync(request.Email, "Reset Password", $"<p>Your reset code is: <strong>{code}</strong></p>");

        return new ForgotPasswordResponse
        {
            Success = true,
            messages = "Reset code has been sent to your email"
        };

    }
    /*public async Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequest request) {
        var user = await _userManager.FindByEmailAsync(request.Email);
            if(user is null)
            {
                return new ResetPasswordResponse
                {
                    Success = false,
                    Message = "Email Not Found"
                };
            }
            else if (user.CodeResetPassword != request.Code)
            {
                return new ResetPasswordResponse
                {
                    Success = false,
                    Message = "invalid code"
                };
            }
            else if (user.PasswordResetCodeExpiry < DateTime.UtcNow)
            {
                return new ResetPasswordResponse
                {
                    Success = false,
                    Message = "code expired"
                };
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user,token,request.Password);
            if (!result.Succeeded)
            {
                return new ResetPasswordResponse
                {
                    Success = false,
                    Message = "Password reset failed",
                    Errors = result.Errors.Select(e=>e.Description).ToList()
                };
            }    
            
            await _emailSender.SendEmailAsync(request.Email, "change password", $"<p> your password changed</p>");
            return new ResetPasswordResponse()
            {
                Success=true,
                Message="password reset successfully"

            };
        }
     */
    public async Task<ResetpassworldResponse> Resetpassworld(ResetpasworldRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return new ResetpassworldResponse
            {
                Success = false,
                messages = "Email Not Found"
            };
        }
        else if (user.CodeResetPassword != request.Code)
        {
            return new ResetpassworldResponse
            {
                Success = false,
                messages = "invalid code"
            };
        }
        else if (user.PasswordResetCodeExpiry < DateTime.UtcNow)
        {
            return new ResetpassworldResponse
            {
                Success = false,
                messages = "Code Expired"
            };
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);
        if (!result.Succeeded)
        {
            return new ResetpassworldResponse
            {
                Success = false,
                messages = "password reset failed",
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }
       
        await _emailSender.SendEmailAsync(request.Email, "change Password:", $"<p>Your Password change</p>");
        user.CodeResetPassword = null;
        await _userManager.UpdateAsync(user);
        return new ResetpassworldResponse
        {
            Success = true,
            messages = "Password has been reset successfully"

        };

    }

    public async Task<LoginResponse> RefreshTokenAsync( TokenApiModel request)
    {
        string accessToken = request.AccessToken;
        Console.WriteLine("accest=" + accessToken);
        string refreshToken = request.RefreshToken;

        var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

        var userName = principal.FindFirst("userName")?.Value;


        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userName);

        if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return new LoginResponse()
            {
                Success = false,
                messages = "invalid client request"
            };
        }

        var newAccessToken = await _tokenService.GenerateAccessToken(user);
        var newRefreshToken = _tokenService.GenerateRefreshToken();
        user.RefreshToken = newRefreshToken;

        await _userManager.UpdateAsync(user);

        return new LoginResponse
        {
            Success = true,
            messages = "Token Refreshed",
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
        };
    }
}