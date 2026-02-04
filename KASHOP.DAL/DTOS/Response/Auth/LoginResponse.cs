using KASHOP.DAL.DTOS.Response.classbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.DTOS.Response.Auth
{
    public  class LoginResponse:BaseResponse
    {
       
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }


    }
}
