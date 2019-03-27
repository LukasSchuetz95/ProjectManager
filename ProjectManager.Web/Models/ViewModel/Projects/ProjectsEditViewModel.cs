using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class ProjectsEditViewModel
    {
        //public Project Project { get; set; }

        //public void LoadData(IUnitOfWork uow, int id)
        //{
        //    Project = uow.Projects.GetById(id);
        //}

        public Project Project { get; set; }

        public Employee EditEmployee { get; set; }

        public SelectList ProjectManagersAndMembers { get; set; }

        public void LoadData(IUnitOfWork unitOfWork, int projectId)
        {
            Project = unitOfWork.Projects.GetById(projectId);

            EditEmployee = unitOfWork.EmployeeProjects.GetProjectManagerByProjectId(projectId).Employee;

            List<EmployeeQualification> projectmanagers = unitOfWork.Employees.GetAllProjectManagersAndProjectMembers(projectId);
            ProjectManagersAndMembers = new SelectList(projectmanagers, nameof(EmployeeQualification.EmployeeId), nameof(EmployeeQualification.Employee));
        }
    }
}
