using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Core.Contracts;

namespace ProjectManager.Web.Models.ViewModel
{
    public class TasksListViewModel
    {
        public List<Core.Entities.Task> Tasks { get; set; }

        internal void LoadData(IUnitOfWork unitOfWork)
        {
            Tasks = unitOfWork.Tasks.GetAll();
        }
    }
}
