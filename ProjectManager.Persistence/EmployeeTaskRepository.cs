using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Persistence
{
    public class EmployeeTaskRepository : IEmployeeTaskRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public EmployeeTaskRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Task model)
        {
            _dbContext.Add(model);
        }

        public List<EmployeeTask> GetAllStatuses()
        {
            return _dbContext.EmployeeTasks.Include(e => e.Employee).Include(t => t.Task).OrderBy(p => p.Task.Status).ToList();     

            throw new NotImplementedException();
        }

        public EmployeeTask GetEmployeeTaskByTaskId(int taskId)
        {
            return _dbContext.EmployeeTasks.Include(e => e.Employee).Include(t => t.Task).Where(t => t.TaskId == taskId).SingleOrDefault();
        }

        public void update(Task model)
        {
            _dbContext.Update(model);
        }
    }
}
