using Microsoft.AspNetCore.Identity;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Enum;
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

            if (await userManager.FindByNameAsync("lukas.schuetz1@gmail.com") == null)
            {
                //Employee employee = new Employee
                //{
                //    Id = 1,
                //    Firstname = "Lukas",
                //    Lastname = "Schuetz",
                //    Status = Core.Enum.EmployeeStatusType.Active,
                //    DepartmentId = 1,
                //    Birthdate = new DateTime(1995, 4, 22),
                //    HiringDate = new DateTime(2011, 12, 24),
                //    Phonenumber = "0660/ 4878 299",
                //    Residence = "Bad Hall",
                //    StreetNameAndNr = "Roemerstr. 41",
                //    ZipCode = "4540",
                //    Job = "Software Developer"
                //};

                //using (IUnitOfWork uow = new UnitOfWork())
                //{
                //    await uow.Employees.AddAsync(employee);
                //}


                var user = new ApplicationUser
                {
                    UserName = "lukas.schuetz1@gmail.com",
                    Email = "lukas.schuetz1@gmail.com",
                    EmployeeId = 1
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
