using KASHOP.DAL.DTOS.Request;
using KASHOP.DAL.DTOS.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.serveic
{
    public interface IAuthenticationService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest);
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }

}

