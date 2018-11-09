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

        public List<EmployeeProject> GetAll()
        {
            return _dbContext.EmployeeProjects.Include(e => e.Employee).Include(p => p.Project).OrderBy(e => e.Id).ToList();
        }

        public List<EmployeeProject> GetAllByProjectId(int projectId)
        {
            return _dbContext.EmployeeProjects.Include(e => e.Employee).Include(p => p.Project).Where(p => p.Project.Id == projectId).OrderBy(e => e.Id).ToList();
        }
    }
}
