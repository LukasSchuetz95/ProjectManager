using Microsoft.AspNetCore.Identity;
using ProjectManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Data
{
    public class SeedData
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";

            string role1 = "Admin";
            string role2 = "Member";

            string password = "NewVision2019!";

            if(await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2));
            }

            //if (await userManager.FindByNameAsync("admin@newvision.at") == null)
            //{
            //    var user = new ApplicationUser
            //    {
            //        UserName = "admin@newvision.at",
            //        Email = "admin@newvision.at",
            //        EmployeeId = 112412
            //    };

            //    var result = await userManager.CreateAsync(user);
            //    if (result.Succeeded)
            //    {
            //        await userManager.AddPasswordAsync(user, password);
            //        await userManager.AddToRoleAsync(user, role1);
            //    }
            //    adminId1 = user.Id;
            //}
        }
    }
}
