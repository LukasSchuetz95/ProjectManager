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
        public List<Core.Entities.Task> UndefinedTasks { get; set; }
        public List<Core.Entities.Task> ProcessingTasks { get; set; }
        public List<Core.Entities.Task> CompletedTasks { get; set; }
        public Project Projects { get; set; }

        public void LoadData(IUnitOfWork unitOfWork, int projectId)
        {
            EmployeeProjects = unitOfWork.EmployeeProjects.GetAllByProjectId(projectId);
            Projects = unitOfWork.Projects.GetById(projectId);
            UndefinedTasks = unitOfWork.Tasks.GetAllTasksForProjectWithUndefinedStatus(projectId);
            ProcessingTasks = unitOfWork.Tasks.GetAllTasksForProjectWithProcessingStatus(projectId);
            CompletedTasks = unitOfWork.Tasks.GetAllTasksForProjectWithCompletedStatus(projectId);
        }
    }
}
