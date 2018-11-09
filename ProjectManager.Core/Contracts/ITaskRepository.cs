using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Core.Entities;
using Task = ProjectManager.Core.Entities.Task;

namespace ProjectManager.Core.Contracts
{
    public interface ITaskRepository
    {
        List<Task> GetAll();
        //void Add( Task model);
        List<Task> GetAllTasksForProjectWithUndefinedStatus(int projectId);
        List<Task> GetAllTasksForProjectWithProcessingStatus(int projectId);

        void Update(Task task);
        void Add(System.Threading.Tasks.Task model);
        List<Task> GetAllTasksForProjectWithCompletedStatus(int projectId);
    }
}
