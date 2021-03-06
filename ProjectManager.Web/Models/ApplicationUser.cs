﻿using Microsoft.AspNetCore.Identity;
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
        //Navigation Property to Employee
        [ForeignKey(nameof(EmployeeId))]
        [NotMapped]
        public virtual Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
