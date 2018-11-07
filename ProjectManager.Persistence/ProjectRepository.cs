using ProjectManager.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Persistence
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public ProjectRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
