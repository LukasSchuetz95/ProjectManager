using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = ProjectManager.Core.Entities.Task;

namespace ProjectManager.Web.Models.ViewModel
{
    public class TasksCreateViewModel
    {
        public EmployeeTask EmployeeTask { get; set; }
        public SelectList Employees { get; set; }

        public Project Project { get; set; }
        public Task Task { get; set; }

        public int ProjectId { get; set; }

        public void LoadData(IUnitOfWork uow, int projectId)
        {
            List<EmployeeProject> employees = uow.EmployeeProjects.GetAllByProjectId(projectId);
            Employees = new SelectList(employees, nameof(Employee.Id), nameof(Employee));
            this.Project = uow.Projects.GetById(projectId);
            this.ProjectId = projectId;
        }
    }
}