using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Persistence
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public ProjectRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Project model)
        {
            _dbContext.Project.Add(model);
        }

        public void Delete(Project model)
        {
            _dbContext.Project.Remove(model);
        }

        public List<Project> GetAll()
        {
            return _dbContext.Project.OrderBy(p => p.ProjectName).ToList();
        }

        public List<Project> GetAllStatuses()
        {
            return _dbContext.Project.OrderBy(p => p.Status).ToList();
        }

        public Project GetById(int projectId)
        {
            return _dbContext.Project.Where(p => p.Id == projectId).FirstOrDefault();
        }

        public List<Project> GetProjectByName(string filter)
        {
            IQueryable<Project> query = _dbContext.Project.OrderBy(p => p.ProjectName);

            if(filter == null || filter == "")
            {
                return query.ToList();
            }
            else
            {
                return query.Where(p => p.ProjectName.Contains(filter)).ToList();
            }
        }

        public void Update(Project project)
        {
            _dbContext.Project.Update(project);
        }
    }
}
