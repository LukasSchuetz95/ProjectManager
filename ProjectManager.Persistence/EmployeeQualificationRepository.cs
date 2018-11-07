using ProjectManager.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Persistence
{
    public class EmployeeQualificationRepository : IEmployeeQualificationRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public EmployeeQualificationRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
