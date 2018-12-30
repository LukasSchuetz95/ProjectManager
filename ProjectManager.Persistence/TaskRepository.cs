using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Persistence
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public TaskRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Task task)
        {
            _dbContext.Tasks.Add(task);
        }

        public void Delete(Task model)
        {
            _dbContext.Tasks.Remove(model);
        }

        public List<Task> GetAll()
        {
            return _dbContext.Tasks.Include(ord => ord.Project).OrderBy(ord => ord.Project).ToList();
        }

        public List<Task> GetAllTasksForProjectWithCompletedStatus(int projectId)
        {
            return _dbContext.Tasks.Where(p => (p.ProjectId == projectId) && (p.Status == TaskStatusType.Erledigt)).ToList();
        }

        public List<Task> GetAllTasksForProjectWithCompletedStatus()
        {
            return _dbContext.Tasks.Where(p=> p.Status == TaskStatusType.Erledigt).ToList();
        }

        public List<Task> GetAllTasksForProjectWithProcessingStatus(int projectId)
        {
            return _dbContext.Tasks.Where(p => (p.ProjectId == projectId) && (p.Status == TaskStatusType.InArbeit)).ToList();
        }

        public List<Task> GetAllTasksForProjectWithProcessingStatus()
        {
            return _dbContext.Tasks.Where(p => p.Status == TaskStatusType.InArbeit).ToList();
        }

        public List<Task> GetAllTasksForProjectWithUndefinedStatus(int projectId)
        {
            return _dbContext.Tasks.Where(p => (p.ProjectId == projectId) && (p.Status == TaskStatusType.NichtBegonnen)).ToList();
        }

        public List<Task> GetAllTasksForProjectWithUndefinedStatus()
        {
            return _dbContext.Tasks.Where(p => p.Status == TaskStatusType.NichtBegonnen).ToList();
        }

        public Task GetById(int tasikId)
        {
            return _dbContext.Tasks.Where(t => t.Id == tasikId).FirstOrDefault();
        }

        public List<Task> GetTaskByName(string filter)
        {
            IQueryable<Task> query = _dbContext.Tasks.OrderBy(p => p.TaskName);

            if (filter == null || filter == "")
            {
                return query.ToList();
            }
            else
            {
                return query.Where(p => p.TaskName.Contains(filter)).ToList();
            }
        }

        public void Update(Task task)
        {
            _dbContext.Tasks.Update(task);
        }

    }
}
