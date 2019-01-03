using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class EmployeesProfilViewModel
    {
        public Employee Employee { get; set; }

        public Department Department { get; set; }

        public List<EmployeeProject> projectOfEmployee { get; set; }

        public void LoadData(IUnitOfWork unitOfWork, int employeeId)
        {
            Employee = unitOfWork.Employees.GetById(employeeId);
            unitOfWork.Departments.GetAll();
            projectOfEmployee = unitOfWork.EmployeeProjects.GetProjectsByEmployeeId(employeeId);
        }
    }
}
