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
            _dbContext.EmployeeProjects.Add(model);
        }

        public void Delete(EmployeeProject model)
        {
            _dbContext.EmployeeProjects.Remove(model);
        }

        public List<EmployeeProject> GetAll()
        {
            return _dbContext.EmployeeProjects.Include(e => e.Employee).Include(p => p.Project).OrderBy(e => e.Id).ToList();
        }

        public List<EmployeeProject> GetAllByProjectId(int projectId)
        {
            return _dbContext.EmployeeProjects.Include(e => e.Employee).Include(p => p.Project)
                .Where(p => p.ProjectId == projectId).OrderBy(e => e.Id).ToList();
        }

        public List<Employee> GetAllNotPartOfProject(int projectId)
        {
            List<EmployeeProject> list = GetAllByProjectId(projectId);

            List<Employee> employees = _dbContext.Employees.ToList();

            List<Employee> newemployees = _dbContext.Employees.ToList();

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

        public EmployeeProject GetById(int empProId)
        {
            return _dbContext.EmployeeProjects.SingleOrDefault(e => e.Id == empProId);
        }

        public EmployeeProject GetByProjectId(int id)
        {
            return _dbContext.EmployeeProjects.Where(p => p.ProjectId == id).FirstOrDefault();
        }

        public List<EmployeeProject> GetProjectsByEmployeeId(int employeeId)
        {
            return _dbContext.EmployeeProjects.Include(e => e.Employee).Include(p => p.Project).Where(p => p.EmployeeId == employeeId).ToList();
        }
    }
}
