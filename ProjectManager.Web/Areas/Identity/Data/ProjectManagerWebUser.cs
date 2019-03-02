using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjectManager.Web.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ProjectManagerWebUser class
    public class ProjectManagerWebUser : IdentityUser
    {
        public string FirstName { get; set; }
    }
}
