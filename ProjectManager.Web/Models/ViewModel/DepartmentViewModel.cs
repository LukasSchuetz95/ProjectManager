using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class DepartmentsViewModel
    {
        public List<Employee> EmployeeList { get; set; }
        public List<Department> DepartmentList { get; set; }
        public Department Department { get; set; }
    }
}
