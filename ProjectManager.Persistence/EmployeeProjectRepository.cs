using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;

namespace ProjectManager.Persistence
{
    public class EmployeeProjectRepository : IEmployeeProjectRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public EmployeeProjectRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(EmployeeProject model)
        {
            _dbContext.EmployeeProject.Add(model);
        }

        public void Delete(EmployeeProject model)
        {
            _dbContext.EmployeeProject.Remove(model);
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <returns></returns>
        public List<EmployeeProject> GetAll()
        {
            return _dbContext.EmployeeProject.Include(e => e.Employee).Include(p => p.Project).OrderBy(e => e.Id).ToList();
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<EmployeeProject> GetAllByProjectId(int projectId)
        {
            return _dbContext.EmployeeProject.Include(e => e.Employee).Include(p => p.Project)
                .Where(p => p.ProjectId == projectId).OrderBy(e => e.Id).ToList();
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<Employee> GetAllNotPartOfProject(int projectId)
        {
            List<EmployeeProject> list = GetAllByProjectId(projectId);

            List<Employee> employees = _dbContext.Employee.ToList();

            List<Employee> newemployees = _dbContext.Employee.ToList();

            foreach (var i in list)
            {
                foreach (var j in employees)
                {
                    if (i.EmployeeId == j.Id)
                    {
                        newemployees.Remove(j);
                    }
                }
            }

            return newemployees;
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="empId"></param>
        /// <returns></returns>
        public EmployeeProject GetByEmployeeIdAndProjectId(int projectId, int empId)
        {
            return _dbContext.EmployeeProject.SingleOrDefault(p => p.EmployeeId == empId && p.ProjectId == projectId);
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="empProId"></param>
        /// <returns></returns>
        public EmployeeProject GetById(int empProId)
        {
            return _dbContext.EmployeeProject.SingleOrDefault(e => e.Id == empProId);
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeProject GetByProjectId(int id)
        {
            return _dbContext.EmployeeProject.Where(p => p.ProjectId == id).FirstOrDefault();
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="filterEmployeeName"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<EmployeeProject> GetEmplyoeesInProjectByEmployeeName(string filterEmployeeName, int projectId)
        {
            IQueryable<EmployeeProject> emp = _dbContext.EmployeeProject.Include(e => e.Employee).Include(p => p.Project);
                

            if (filterEmployeeName == null || filterEmployeeName == "")
            {
                return emp.Where(p => p.ProjectId == projectId).OrderBy(e => e.Id).ToList();
            }
            else
            {
                return emp.Where(p => p.Employee.ToString().Contains(filterEmployeeName) && p.ProjectId == projectId).OrderBy(e => e.Id).ToList();
            }

        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="filterEmployeeName"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<Employee> GetEmplyoeesNotInProjectByEmployeeName(string filterEmployeeName, int projectId)
        {

            List<EmployeeProject> list = GetAllByProjectId(projectId);

            List<Employee> employees = _dbContext.Employee.ToList();

            List<Employee> newemployees = _dbContext.Employee.ToList();

            foreach (var i in list)
            {
                foreach (var j in employees)
                {
                    if (i.EmployeeId == j.Id)
                    {
                        newemployees.Remove(j);
                    }
                }
            }

            if (filterEmployeeName == null || filterEmployeeName == "")
            {
                return newemployees.OrderBy(e => e.Id).ToList();
            }
            else
            {
                return newemployees.Where(e => e.ToString().Contains(filterEmployeeName)).OrderBy(e => e.Id).ToList();
            }
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public EmployeeProject GetProjectManagerByProjectId(int projectId)
        {
            return _dbContext.EmployeeProject.Include(e => e.Employee).Include(pr => pr.Project).Where(p => p.ProjectId == projectId && p.Projectmanager == true).SingleOrDefault();
        }

        
        public List<EmployeeProject> GetProjectsByEmployeeId(int employeeId)
        {
            return _dbContext.EmployeeProject.Include(e => e.Employee).Include(p => p.Project).Where(p => p.EmployeeId == employeeId).ToList();
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="projectId"></param>
        public void SetAllProjectManagersToFalse(int projectId)
        {
            _dbContext.EmployeeProject.Where(p => p.ProjectId == projectId).ToList().ForEach(pp => pp.Projectmanager = false);
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="employeeProject"></param>
        public void Update(EmployeeProject employeeProject)
        {
            _dbContext.EmployeeProject.Update(employeeProject);
        }
    }
}
