using ProjectManager.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class TasksViewModel
    {
        public List<Task> Tasks { get; set; }

        //public void LoadData(IUnitOfWork uow, int id)
        //{
        //    Tasks = uow.Tasks.GetAll();
        //}
    }
}

