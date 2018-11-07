using ProjectManager.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Persistence
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public DepartmentRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
