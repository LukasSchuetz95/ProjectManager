using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Persistence
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> GetAll(string Filter)
        {
            return _dbContext.Employees.OrderBy(e => e.Lastname).ThenBy(e => e.Firstname).ToList();
        }
    }
}
