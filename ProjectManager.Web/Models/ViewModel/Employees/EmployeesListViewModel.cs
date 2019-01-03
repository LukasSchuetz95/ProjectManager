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
        public string FilterLastname { get; set; }
        public string FilterFirstname { get; set; }
        public string FilterJob { get; set; }
        public string FilterDepartmentName { get; set; }

        //StandardbennenungController+Actionmodel
    }
}
