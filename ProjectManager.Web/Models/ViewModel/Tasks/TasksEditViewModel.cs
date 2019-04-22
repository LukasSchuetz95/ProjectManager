using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class TasksEditViewModel
    {
        public Employee Employee { get; set; }
        public EmployeeTask EmployeeTask { get; set; }
        public SelectList Employees { get; set; }

        public Project Project { get; set; }
        //public System.Threading.Tasks.Task Task { get; set; }

        public int ProjectId { get; set; }

        public Core.Entities.Task Tasks { get; set; }



        public void LoadData(IUnitOfWork uow, int taskId, int projectId)
        {
            Tasks = uow.Tasks.GetById(taskId);
            List<EmployeeProject> employees = uow.EmployeeProjects.GetAllByProjectId(projectId);
            Employees = new SelectList(employees, nameof(EmployeeProject.EmployeeId), nameof(Employee));
            this.Project = uow.Projects.GetById(projectId);
            this.ProjectId = projectId;
        }

    }


}

