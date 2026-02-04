using KASHOP.DAL.DTOS.Request.Auth;
using KASHOP.DAL.DTOS.Request.Token;
using KASHOP.DAL.DTOS.Response.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.serveic.auth
{
    public interface IAuthenticationService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest);
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
        Task<bool> ConfirmEmailAsync(string token, string userid);
        Task<ForgotPasswordResponse> RequestPasswordReset(ForgotPasswordRequest request);
        Task<ResetpassworldResponse> Resetpassworld(ResetpasworldRequest request);
        Task<LoginResponse> RefreshTokenAsync(TokenApiModel request);


    }
}

