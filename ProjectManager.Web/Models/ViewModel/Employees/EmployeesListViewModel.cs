using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class EmployeesListViewModel
    {
        public List<Employee> Employees { get; set; }
        [Display(Name = "LookingForEmployee")]
        public string Filter { get; set; }
        public string LastnameFilter { get; set; }
        public string FirstnameFilter { get; set; }
        public string JobFilter { get; set; }
        public string DepartmentFilter { get; set; }

        public bool SwitchOrderFirstName { get; set; }
        public bool SwitchOrderLastName { get; set; }
        public bool SwitchOrderJob { get; set; }
        public bool SwitchOrderDepartment { get; set; }
    }
}
