using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.DTOS.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string messages { get; set; }
        public List<string>? Errors { get; set; } = new List<string>();
    }
}
