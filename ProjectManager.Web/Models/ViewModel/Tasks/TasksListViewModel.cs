using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;

namespace ProjectManager.Web.Models.ViewModel
{
    public class TasksListViewModel
    {
        public List<Core.Entities.Task> Tasks { get; set; }
        public List<Core.Entities.Task> UndefinedTasks { get;  set; }
        public List<Core.Entities.Task> ProcessingTasks { get;  set; }
        public List<Core.Entities.Task> CompletedTasks { get;  set; }
        public string FilterTaskName { get; set; }

        internal void LoadData(IUnitOfWork unitOfWork)
        {
            Tasks = unitOfWork.Tasks.GetAll();
            UndefinedTasks = unitOfWork.Tasks.GetAllTasksForProjectWithUndefinedStatus();
            ProcessingTasks = unitOfWork.Tasks.GetAllTasksForProjectWithProcessingStatus();
            CompletedTasks = unitOfWork.Tasks.GetAllTasksForProjectWithCompletedStatus();
        }
    }
}
