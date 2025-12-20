using KASHOP.DAL.DTOS.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.DTOS.Request
{
    public class ResetpasworldRequest
    {
        public string Code { get; set; }
        public string NewPassword { get; set; }
        public string Email { get; set; }
    }

}
