using Microsoft.AspNetCore.Identity;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {

        }

        [ForeignKey(nameof(EmployeeId))]
        [NotMapped]
        public virtual Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        //UserManager<IdentityUser> userManager; // DI injected

        //var user = await userManager.Users
        //    .Include(x => x.Employee)
        //    .SingleAsync(x => x.NormalizedEmail == email);

    }
}
