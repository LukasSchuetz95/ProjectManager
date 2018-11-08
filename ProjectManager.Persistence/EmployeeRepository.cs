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

        public List<Employee> GetEmployeeByLastname(string filter)
        {
            IQueryable<Employee> query = _dbContext.Employees.OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

            if (filter == null || filter == "")
            {
                return query.ToList();
            }
            else
            {
                return query.Where(e => e.Lastname.StartsWith(filter)).ToList();
            }
        }

        public List<Employee> GetEmployeeByFirstname(string filter)
        {
            IQueryable<Employee> query = _dbContext.Employees.OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

            if (filter == null || filter == "")
            {
                return query.ToList();
            }
            else
            {
                return query.Where(e => e.Firstname.StartsWith(filter)).ToList();
            }
        }

        public List<Employee> GetEmployeeByJob(string filter)
        {
            IQueryable<Employee> query = _dbContext.Employees.OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

            if (filter == null || filter == "")
            {
                return query.ToList();
            }
            else
            {
                return query.Where(e => e.Job.StartsWith(filter)).ToList();
            }
        }
    }
}
