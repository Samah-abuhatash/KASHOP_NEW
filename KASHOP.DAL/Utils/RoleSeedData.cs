using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Utils
{
    public class RoleSeedData : ISeedData
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        //serves add scop recod 
        public RoleSeedData(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task DataSeed()
        {
            string[] roles = ["SuperAdmin", "Admin", "User"];
            //no data===>add 
            if (!await _roleManager.Roles.AnyAsync())
            {

                foreach (var role in roles)
                {

                  await  _roleManager.CreateAsync(new IdentityRole(role));
                }
            }//if

        }
    }
}
        
