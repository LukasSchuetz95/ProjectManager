using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Contracts;

namespace ProjectManager.Persistence
{
    public class TaskQualificationRepository : ITaskQualificationRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public TaskQualificationRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
