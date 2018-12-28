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

        public List<EmployeeProject> EmployeeProject { get; set; }


        public void LoadData(IUnitOfWork uow, int projectId)
        {
            var employees = uow.Employees.GetAll();
            Employees = new SelectList(employees, nameof(Employee.Id), null);

            //var project = uow.Projects.GetAll();
            //Project = new SelectList(project, nameof(Task.ProjectId), null);

            Project = uow.Projects.GetById(projectId);

            EmployeeProject = uow.EmployeeProjects.GetAllByProjectId(projectId);
        }
    }
}