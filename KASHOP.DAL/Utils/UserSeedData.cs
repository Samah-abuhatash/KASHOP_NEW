using KASHOP.DAL.Moadels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Utils
{
    public class UserSeedData : ISeedData
    {
        private readonly UserManager<Applicationuser> _userManager;

        public UserSeedData(UserManager<Applicationuser>userManager)
        {
            _userManager = userManager;
        }
        public  async Task DataSeed()
        {
            if(!await _userManager.Users.AnyAsync())
            {
                var user1 = new Applicationuser
                {
                    UserName = "tshreem",
                    Email = "t@gmail.com",
                    FullName = "Tariq Shreem",
                    EmailConfirmed = true
                };

                var user2 = new Applicationuser
                {
                    UserName = "DRabaya",
                    Email = "d@gmail.com",
                    FullName = "Duha Rabaya",
                    EmailConfirmed = true
                };

                var user3 = new Applicationuser
                {
                    UserName = "Abed",
                    Email = "a@gmail.com",
                    FullName = "Abed Edaily",
                    EmailConfirmed = true
                };
                //"SuperAdmin", "Admin", "User"
                await _userManager.CreateAsync(user1,"Pass@1122");
                await _userManager.CreateAsync(user2, "Pass@1122");
                await _userManager.CreateAsync(user3, "Pass@1122");
                await _userManager.AddToRoleAsync(user1, "SuperAdmin");
                await _userManager.AddToRoleAsync(user2, "Admin");
                await _userManager.AddToRoleAsync(user3, "User");

            }
        
        }
    }
}
