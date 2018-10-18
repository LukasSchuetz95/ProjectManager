using ProjectManager.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Persistence
{
    public class EmployeeQualificationRepository : IEmployeeQualificationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeQualificationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
