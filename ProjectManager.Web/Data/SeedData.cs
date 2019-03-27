using Microsoft.AspNetCore.Identity;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Persistence;
using ProjectManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Data
{
    public class SeedData
    {
        public static async System.Threading.Tasks.Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";

            string role1 = "Admin";
            string role2 = "Member";

            string password = "Admin1!";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2));
            }

            if (await userManager.FindByNameAsync("admin@admin.com") == null)
            {
                Employee employee = new Employee
                {
                    Firstname = "Admin",
                    Lastname = "Admin",
                    Status = Core.Enum.EmployeeStatusType.Beschäftigt,
                    DepartmentId = 1
                };

                using (IUnitOfWork uow = new UnitOfWork())
                {
                    await uow.Employees.AddAsync(employee);
                }
                

                var user = new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmployeeId = employee.Id
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }
        }
    }
}
