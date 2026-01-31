using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.DTOS.Request.Auth
{
    public  class RegisterRequest
    {//LoginRequest
        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber {  get; set; }
    }
}
