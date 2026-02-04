using KASHOP.BLL.serveic.auth;
using KASHOP.DAL.DTOS.Request.Auth;
using KASHOP.DAL.DTOS.Request.Token;
using KASHOP.DAL.DTOS.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP2.PL.Areas.Identy
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AcountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authenticationService.RegisterAsync(request);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> login(LoginRequest request)
        {
            var result = await _authenticationService.LoginAsync(request);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string userId)
        {
            var result = await _authenticationService.ConfirmEmailAsync(token, userId);
            return Ok(result);
        }
        [HttpPost("SendCode")]
        public async Task<IActionResult> RequestPasswordReset(ForgotPasswordRequest request)
        {
            var result = await _authenticationService.RequestPasswordReset(request);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }



        [HttpPatch("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetpasworldRequest request)
        {
            var result = await _authenticationService.Resetpassworld(request);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPatch("RefreshToken")]
        public async Task<IActionResult> RefreshTokenAsync(TokenApiModel request)
        {
            var result = await _authenticationService.RefreshTokenAsync(request);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
