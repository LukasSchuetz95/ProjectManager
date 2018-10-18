using ProjectManager.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Persistence
{
    public class EmployeeTaskRepository : IEmployeeTaskRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeTaskRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
