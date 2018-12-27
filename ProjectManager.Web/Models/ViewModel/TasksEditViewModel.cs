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
        public SelectList TaskMembers { get;  set; }
        public Core.Entities.Task Tasks { get; set; }
        public Employee EditEmployee { get; internal set; }

        public void LoadData(IUnitOfWork uow, int taskId)
        {
            EmployeeTask = uow.EmployeeTasks.GetEmployeeTaskByTaskId(taskId);

            TaskMembers= new SelectList( nameof(EmployeeQualification.EmployeeId), nameof(EmployeeQualification.Employee));

            Tasks = uow.Tasks.GetById(taskId);
        }

       
    }
}
