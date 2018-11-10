using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class TasksCreateViewModel
    {
        public EmployeeTask EmployeeTask { get; set; }

        public SelectList List { get; set; }

        

        public void LoadData(IUnitOfWork uow)
        {
            var list = uow.EmployeeTasks.GetAllStatuses();
            List = new SelectList(list, nameof(EmployeeTask.Task.Status), null);
        }
 

    }
}
