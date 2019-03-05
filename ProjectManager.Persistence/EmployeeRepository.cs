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

        public void Add(Employee employee)
        {
            _dbContext.Employee.Add(employee);
        }
        public void Update(Employee employee)
        {
            _dbContext.Employee.Update(employee);
        }

        public List<Employee> GetEmployeeByLastname(string filter)
        {
            IQueryable<Employee> query = _dbContext.Employee.Include(e=> e.Department).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

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
            IQueryable<Employee> query = _dbContext.Employee.Include(e => e.Department).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

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
            IQueryable<Employee> query = _dbContext.Employee.Include(e => e.Department).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

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
            IQueryable<Employee> query = _dbContext.Employee.Include(e => e.Department).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);

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
            return _dbContext.Employee.Where(p => p.Id == employeeId).FirstOrDefault();
        }

        public List<Employee> GetAll()
        {
            return _dbContext.Employee.OrderBy(e => e.Firstname).ThenBy(e => e.Lastname).ToList();
        }

        public List<EmployeeQualification> GetAllProjectManagersAndProjectMembers(int projectId)
        {
            List<EmployeeQualification> projectManagers = _dbContext.EmployeeQualification.Include(e => e.Employee).Include(q => q.Qualification).
                Where(e => e.Qualification.QualificationName == "Projekt Manager").ToList();

            List<EmployeeProject> employeeProjects = _dbContext.EmployeeProject.Where(p => p.ProjectId == projectId).ToList();

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
            List<Employee> empList = _dbContext.Employee.Where(e => e.DepartmentId == id).OrderBy(e =>e.Lastname).ThenBy(e => e.Firstname).ToList();

            return empList;
        }

        
    }
}
