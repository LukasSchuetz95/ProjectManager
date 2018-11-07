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
        private readonly ApplicationDbContextPersistence _dbContext;

        public EmployeeRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> GetEmployeeByLastname(string Filter)
        {
            IQueryable<Employee> query = _dbContext.Employees.OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

            if (Filter == null || Filter == "")
            {
                return query.ToList(); /*_dbContext.Employees.OrderBy(e => e.Lastname).ThenBy(e => e.Firstname).ToList();*/
            }
            else
            {
                return query.Where(e => e.Lastname.StartsWith(Filter)).ToList();
                //_dbContext.Employees.OrderBy(e => e.Lastname)
                //.ThenBy(e => e.Firstname).Where(e => e.Lastname.StartsWith(Filter)).ToList();
            }
        }

        public List<Employee> GetEmployeeByFirstname(string Filter)
        {
            IQueryable<Employee> query = _dbContext.Employees.OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

            if (Filter == null || Filter == "")
            {
                return query.ToList();
            }
            else
            {
                return query.Where(e => e.Firstname.StartsWith(Filter)).ToList();
            }
        }
    }
}
