using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class TasksDetailsViewModel
    {
        public EmployeeTask EmployeeTask { get; set; }
        public Core.Entities.Task Task { get; set; }

        public void LoadData(IUnitOfWork uow, int taskId)
        {
            EmployeeTask = uow.EmployeeTasks.GetEmployeeTaskByTaskId(taskId);
            Task = uow.Tasks.GetById(taskId);
        }
    }
}
