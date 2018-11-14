using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class EmployeeProjectsCreateViewModel
    {
        public EmployeeProject EmployeeProject { get; set; }

        public List<Employee> Employees { get; set; }

        public void LoadData(IUnitOfWork unitOfWork, int projectId)
        {
            EmployeeProject = unitOfWork.EmployeeProjects.GetByProjectId(projectId);

            Employees = unitOfWork.Employees.GetAll();
        }
    }
}
