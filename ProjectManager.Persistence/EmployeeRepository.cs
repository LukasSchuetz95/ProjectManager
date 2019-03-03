using Microsoft.EntityFrameworkCore;
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

        public void Update(Employee employee)
        {
            _dbContext.Employees.Update(employee);
        }

        public List<Employee> GetEmployeeByLastname(string filter)
        {
            IQueryable<Employee> query = _dbContext.Employees.Include(e=> e.Department).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

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
            IQueryable<Employee> query = _dbContext.Employees.Include(e => e.Department).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

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
            IQueryable<Employee> query = _dbContext.Employees.Include(e => e.Department).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

            if (filter == null || filter == "")
            {
                return query.ToList();
            }
            else
            {
                return query.Where(e => e.Job.StartsWith(filter)).ToList();
            }
        }

        public List<Employee> GetEmployeeByDeparmentName(string filter)
        {
            IQueryable<Employee> query = _dbContext.Employees.Include(e => e.Department).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

            if (filter == null || filter == "")
            {
                return query.ToList();
            }
            else
            {
                return query.Where(e => e.Department.DeptName.StartsWith(filter)).ToList();
            }
        }

        public Employee GetById(int employeeId)
        {
            return _dbContext.Employees.Where(p => p.Id == employeeId).FirstOrDefault();
        }

        public List<Employee> GetAll()
        {
            return _dbContext.Employees.OrderBy(e => e.Firstname).ThenBy(e => e.Lastname).ToList();
        }

        public List<EmployeeQualification> GetAllProjectManagersAndProjectMembers(int projectId)
        {
            List<EmployeeQualification> projectManagers = _dbContext.EmployeeQualifications.Include(e => e.Employee).Include(q => q.Qualification).
                Where(e => e.Qualification.QualificationName == "Projekt Manager").ToList();

            List<EmployeeProject> employeeProjects = _dbContext.EmployeeProjects.Where(p => p.ProjectId == projectId).ToList();

            List<EmployeeQualification> employees = new List<EmployeeQualification>();

            foreach (var pm in projectManagers)
            {
                foreach (var ep in employeeProjects)
                {
                    if (pm.EmployeeId == ep.EmployeeId)
                    {
                        employees.Add(pm);
                    }
                }
            }

            return employees;
        }

        public List<Employee> GetEmployeeByDepartmentId(int id)
        {
            List<Employee> empList = _dbContext.Employees.Where(e => e.DepartmentId == id).OrderBy(e =>e.Lastname).ThenBy(e => e.Firstname).ToList();

            return empList;
        }

        public void Add(Employee employee)
        {
            _dbContext.Employees.Add(employee);
        }
    }
}
