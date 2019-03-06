﻿using System;
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

        public List<EmployeeProject> GetAll()
        {
            return _dbContext.EmployeeProject.Include(e => e.Employee).Include(p => p.Project).OrderBy(e => e.Id).ToList();
        }

        public List<EmployeeProject> GetAllByProjectId(int projectId)
        {
            return _dbContext.EmployeeProject.Include(e => e.Employee).Include(p => p.Project)
                .Where(p => p.ProjectId == projectId).OrderBy(e => e.Id).ToList();
        }

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

        public EmployeeProject GetByEmployeeIdAndProjectId(int projectId, int empId)
        {
            return _dbContext.EmployeeProject.SingleOrDefault(p => p.EmployeeId == empId && p.ProjectId == projectId);
        }

        public EmployeeProject GetById(int empProId)
        {
            return _dbContext.EmployeeProject.SingleOrDefault(e => e.Id == empProId);
        }

        public EmployeeProject GetByProjectId(int id)
        {
            return _dbContext.EmployeeProject.Where(p => p.ProjectId == id).FirstOrDefault();
        }

        public EmployeeProject GetProjectManagerByProjectId(int projectId)
        {
            return _dbContext.EmployeeProject.Include(e => e.Employee).Include(pr => pr.Project).Where(p => p.ProjectId == projectId && p.Projectmanager == true).SingleOrDefault();
        }

        public List<EmployeeProject> GetProjectsByEmployeeId(int employeeId)
        {
            return _dbContext.EmployeeProject.Include(e => e.Employee).Include(p => p.Project).Where(p => p.EmployeeId == employeeId).ToList();
        }

        public void SetAllProjectManagersToFalse(int projectId)
        {
            _dbContext.EmployeeProject.Where(p => p.ProjectId == projectId).ToList().ForEach(pp => pp.Projectmanager = false);
        }

        public void Update(EmployeeProject employeeProject)
        {
            _dbContext.EmployeeProject.Update(employeeProject);
        }
    }
}
