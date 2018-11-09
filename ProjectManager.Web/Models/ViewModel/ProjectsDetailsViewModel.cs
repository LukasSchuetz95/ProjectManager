using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class ProjectsDetailsViewModel
    {
        public List<EmployeeProject> EmployeeProjects { get; set; }
        public List<Core.Entities.Task> Tasks { get; set; }
        public Project Projects { get; set; }

        public void LoadData(IUnitOfWork unitOfWork, int projectId)
        {
            EmployeeProjects = unitOfWork.EmployeeProjects.GetAllByProjectId(projectId);
            Projects = unitOfWork.Projects.GetById(projectId);
            Tasks = unitOfWork.Tasks.GetAllTasksForProjectWithUndefinedStatus(projectId);
        }
    }
}
