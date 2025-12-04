using KASHOP.BLL.serveic;
using KASHOP.DAL.DTOS.Request;
using KASHOP.DAL.DTOS.Response;
using KASHOP.DAL.Moadels;
using Mapster;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<Applicationuser> _userManager;

    public AuthenticationService(UserManager<Applicationuser> userManager)
    {
        _userManager = userManager;
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

            var result = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (!result)
            {
                return new LoginResponse
                {
                    Success = false,
                    messages = "Invalid password"
                };
            }

            return new LoginResponse
            {
                Success = true,
                messages = "Login successfully"
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

    
}