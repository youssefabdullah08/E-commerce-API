using Microsoft.AspNetCore.Identity;
using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys
{
    public class identitySeedContext
    {
        public void SeedUser(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                 Email:"Youssef@gmail.com",
                 
                };
        }
    }
}
}
