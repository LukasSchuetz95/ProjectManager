using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Contracts
{
    public interface ITaskRepository
    {
        List<Task> GetAll();
        void Add(Task model);
        List<Task> GetAllTasksForProjectWithUndefinedStatus(int projectId);
        List<Task> GetAllTasksForProjectWithProcessingStatus(int projectId);

        void Update(Task task);
    }
}
