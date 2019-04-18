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

        public List<EmployeeProject> EmployeesInProject { get; set; }

        public List<Employee> EmployeesNotInProject { get; set; }

        public string FilterEmployeeName { get; set; }

        public void LoadData(IUnitOfWork unitOfWork, int projectId)
        {
            EmployeeProject = unitOfWork.EmployeeProjects.GetByProjectId(projectId);

            EmployeesInProject = unitOfWork.EmployeeProjects.GetAllByProjectId(projectId);

            EmployeesNotInProject = unitOfWork.EmployeeProjects.GetAllNotPartOfProject(projectId);
        }
    }
}
