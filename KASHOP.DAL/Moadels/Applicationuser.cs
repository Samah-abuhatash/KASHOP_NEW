using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Moadels
{
    public class Applicationuser:IdentityUser
    {
        public string FullName {  get; set; }
        public string? city  { get; set; }
        public string? Street  { get; set; }
        public string? CodeResetPassword { get; set; }
        public DateTime? PasswordResetCodeExpiry { get; set; }

    }
}
