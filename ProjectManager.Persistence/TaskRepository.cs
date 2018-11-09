using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Persistence
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public TaskRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Task model)
        {
            _dbContext.Add(model);
        }


        public List<Task> GetAll()
        {
            return _dbContext.Tasks.OrderBy(ord => ord.Project).ToList();
        }

        public List<Task> GetAllTasksForProjectWithProcessingStatus(int projectId)
        {
            return _dbContext.Tasks.Where(p => (p.ProjectId == projectId) && (p.Status == TaskStatusType.Laufend)).ToList();
        }

        public List<Task> GetAllTasksForProjectWithUndefinedStatus(int projectId)
        {
            return _dbContext.Tasks.Where(p => (p.ProjectId == projectId) && (p.Status == TaskStatusType.Offen)).ToList();
        }

        public void Update(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
