using ProjectManager.Core.Contracts;
using System;
using System.Collections.Generic;
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
    }
}
