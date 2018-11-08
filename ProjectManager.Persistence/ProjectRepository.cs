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
            _dbContext.Projects.Add(model);
        }

        public List<Project> GetAll()
        {
            return _dbContext.Projects.OrderBy(p => p.ProjectName).ToList();
        }

        public Project GetById(int projectId)
        {
            return _dbContext.Projects.Where(p => p.Id == projectId).FirstOrDefault();
        }

        public List<Project> GetProjectByName(string filter)
        {
            IQueryable<Project> query = _dbContext.Projects.OrderBy(p => p.ProjectName);

            if(filter == null || filter == "")
            {
                return query.ToList();
            }
            else
            {
                return query.Where(p => p.ProjectName.StartsWith(filter)).ToList();
            }
        }
    }
}
