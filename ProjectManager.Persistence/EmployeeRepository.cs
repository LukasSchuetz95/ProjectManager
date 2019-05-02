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

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        public Employee GetById(int employeeId)
        {

            return _dbContext.Employee.Include(p=>p.Department).Where(p => p.Id == employeeId).FirstOrDefault();
        }

        public List<Employee> GetAll()
        {
            return _dbContext.Employee.Include(p=>p.Department).Where(p=>p.Firstname != "Admin" && p.Lastname != "Admin").
                                                                OrderBy(e => e.Lastname).ThenBy(e => e.Firstname).ToList();
        }

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeByDepartmentId(int id)
        {
            List<Employee> empList = _dbContext.Employee.Where(e => e.DepartmentId == id).OrderBy(e => e.Lastname).ThenBy(e => e.Firstname).ToList();

            return empList;
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task AddAsync(Employee employee)
        {
            await _dbContext.Employee.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeesByProjectAndQualifications(int taskId, int employeeId, IUnitOfWork uow)
        {
            List<Employee> employees = new List<Employee>();
            List<EmployeeQualification> qualifiedEmployees = new List<EmployeeQualification>();
            List<EmployeeProject> employeeProjects = new List<EmployeeProject>();

            employeeProjects = uow.EmployeeProjects.GetAllByProjectId(uow.Projects.GetById(uow.Tasks.GetById(taskId).ProjectId).Id);

            List<TaskQualification> taskQualifications = uow.TaskQualifications.GetQualificationsByTaskId(taskId);

            foreach (var tQ in taskQualifications)
            {
                qualifiedEmployees = uow.EmployeeQualifications.GetEmployeesByQualifications(tQ.QualificationId);
            }

            foreach (var qE in qualifiedEmployees)
            {
                foreach (var eP in employeeProjects)
                {
                    if (eP.Employee.Id == qE.Employee.Id && eP.Employee.Id != employeeId)
                    {
                        if (CheckIfEmployeeIsAlreadySaved(eP, employees))
                        {
                            employees.Add(eP.Employee);
                        }
                    }
                }
            }

            return employees;
        }

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        private bool CheckIfEmployeeIsAlreadySaved(EmployeeProject employeeProject, List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                return true;
            }
            else
            {
                foreach (var emp in employees)
                {
                    if (employeeProject.Employee.Id == emp.Id)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #region Methods

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
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
