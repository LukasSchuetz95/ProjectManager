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
        public EmployeeTask EmployeeTask { get; set; }
        public SelectList Employees { get;  set; }
        public Core.Entities.Task Tasks { get; set; }
        public Employee EditEmployee { get; internal set; }
        public List<EmployeeProject> EmployeeProject { get; set; }

        public void LoadData(IUnitOfWork uow, int taskId, int projectId)
        {
            EmployeeTask = uow.EmployeeTasks.GetEmployeeTaskByTaskId(taskId);

            var employees = uow.Employees.GetAll();
            Employees = new SelectList(employees, nameof(Employee.Id), null);

            Tasks = uow.Tasks.GetById(taskId);

            EmployeeProject = uow.EmployeeProjects.GetAllByProjectId(projectId);
        }

       
    }
}
