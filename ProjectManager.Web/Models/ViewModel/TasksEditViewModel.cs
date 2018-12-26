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
        public List<Employee> TaskMembers { get;  set; }
        public object EditEmployee { get; internal set; }

        public void LoadData(IUnitOfWork uow, int taskId)
        {
            EmployeeTask = uow.EmployeeTasks.GetEmployeeTaskByTaskId(taskId);

            TaskMembers = uow.Employees.GetAll();
        }

       
    }
}
