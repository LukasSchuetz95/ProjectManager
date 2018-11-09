using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Contracts
{
    public interface IProjectRepository
    {
        List<Project> GetAll();
        Project GetById(int projectId);
        void Add(Project model);
        List<Project> GetProjectByName(string filter=null);
        void Update(Project project);
        List<Project> GetAllStatuses();
    }
}
