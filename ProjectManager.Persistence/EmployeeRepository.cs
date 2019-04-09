using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Employee> GetEmployeeByLastname(string filter, bool order)
        {
            IQueryable<Employee> query;

            if (order)
            {
                query = _dbContext.Employee.Include(e => e.Department).Where(e => e.Firstname != "Admin" && e.Lastname != "Admin").OrderBy(e => e.Lastname).ThenBy(e => e.Firstname);
            }
            else
            {
                query = _dbContext.Employee.Include(e => e.Department).Where(e => e.Firstname != "Admin" && e.Lastname != "Admin").OrderByDescending(e => e.Lastname).ThenByDescending(e => e.Firstname);
            }

            return ReturnListWithFilter(query, filter, 1);
        }

        public List<Employee> GetEmployeeByFirstname(string filter, bool order)
        {
            IQueryable<Employee> query;

            if (order)
            {
                query = _dbContext.Employee.Include(e => e.Department).Where(e => e.Firstname != "Admin" && e.Lastname != "Admin").OrderBy(e => e.Firstname).ThenBy(e => e.Lastname);
            }
            else
            {
                query = _dbContext.Employee.Include(e => e.Department).Where(e => e.Firstname != "Admin" && e.Lastname != "Admin").OrderByDescending(e => e.Firstname).ThenByDescending(e => e.Lastname);
            }

            return ReturnListWithFilter(query, filter, 2);
        }

        public List<Employee> GetEmployeeByJob(string filter, bool order)
        {
            IQueryable<Employee> query;

            if (order)
            {
                query = _dbContext.Employee.Include(e => e.Department).Where(e => e.Firstname != "Admin" && e.Lastname != "Admin").OrderBy(e => e.Job).ThenBy(e => e.Lastname);
            }
            else
            {
                query = _dbContext.Employee.Include(e => e.Department).Where(e => e.Firstname != "Admin" && e.Lastname != "Admin").OrderByDescending(e => e.Job).ThenByDescending(e => e.Lastname);
            }

            return ReturnListWithFilter(query, filter, 3);
        }

        public List<Employee> GetEmployeeByDeparmentName(string filter, bool order)
        {
            IQueryable<Employee> query;

            if (order)
            {
                query = _dbContext.Employee.Include(e => e.Department).Where(e=>e.Firstname != "Admin" && e.Lastname != "Admin").OrderBy(e => e.Department.DeptName).ThenBy(e => e.Lastname);
            }
            else
            {
                query = _dbContext.Employee.Include(e => e.Department).Where(e => e.Firstname != "Admin" && e.Lastname != "Admin").OrderByDescending(e => e.Department.DeptName).ThenByDescending(e => e.Lastname);
            }

            return ReturnListWithFilter(query, filter, 4);
        }

        public Employee GetById(int employeeId)
        {

            return _dbContext.Employee.Where(p => p.Id == employeeId).FirstOrDefault();
        }

        public List<Employee> GetAll()
        {
            return _dbContext.Employee.Include(p=>p.Department).Where(p=>p.Firstname != "Admin" && p.Lastname != "Admin").
                                                                OrderBy(e => e.Lastname).ThenBy(e => e.Firstname).ToList();
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
            List<Employee> empList = _dbContext.Employee.Where(e => e.DepartmentId == id).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname).ToList();

            return empList;
        }

        public async System.Threading.Tasks.Task AddAsync(Employee employee)
        {
            await _dbContext.Employee.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        List<Employee> GetEmployeesByProjectsAndQualifications(int taskId, int employeeId, IUnitOfWork uow)
        {
            List<Employee> employees = new List<Employee>();
            List<TaskQualification> taskQualifications = new List<TaskQualification>();

            Project project = uow.Projects.GetById(uow.Tasks.GetById(taskId).ProjectId);
            List<TaskQualification> tempTaskQualifications = uow.TaskQualifications.GetQualificationsByTaskId(taskId);

            foreach (var tTQ in tempTaskQualifications)
            {
                if (tTQ.Task.ProjectId == project.Id)
                {
                    taskQualifications.Add(tTQ);
                }
            }

            List<EmployeeQualification> QualifiedEmployees = uow.EmployeeQualifications.GetEmployeesByQualifications(taskQualifications);

            foreach (var qe in QualifiedEmployees)
            {
                employees.Add(uow.Employees.GetById(qe.EmployeeId));
            }

            return employees;
        }

        #region Methods

        private List<Employee> ReturnListWithFilter(IQueryable<Employee> query, string filter, int list)
        {
            if (filter == null || filter.Trim() == "")
            {
                return query.ToList();
            }
            else
            {
                if (list == 1)
                {
                    return query.Where(e => e.Lastname.Contains(filter)).ToList();
                }
                else if (list == 2)
                {
                    return query.Where(e => e.Firstname.Contains(filter)).ToList();
                }
                else if (list == 3)
                {
                    return query.Where(e => e.Job.Contains(filter)).ToList();
                }
                else if (list == 4)
                {
                    return query.Where(e => e.Department.DeptName.Contains(filter)).ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion
    }
}
