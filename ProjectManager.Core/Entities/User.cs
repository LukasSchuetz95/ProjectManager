using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class User : EntityObject
    {
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public int EmployeeId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string PasswordCode { get; set; }

        public bool Admin { get; set; }
    }
}
