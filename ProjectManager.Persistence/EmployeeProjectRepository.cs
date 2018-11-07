using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Contracts;

namespace ProjectManager.Persistence
{
    public class EmployeeProjectRepository : IEmployeeProjectRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public EmployeeProjectRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
