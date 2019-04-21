using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Core.Entities;
using Task = ProjectManager.Core.Entities.Task;

namespace ProjectManager.Core.Contracts
{
    public interface ITaskRepository
    {
        List<Task> GetAll();
        //void Add( Task model);
        List<Task> GetAllTasksForProjectWithUndefinedStatus(int projectId);
        List<Task> GetAllTasksForProjectWithProcessingStatus(int projectId);

        void Update(Task task);
        void Add(Task model);
        List<Task> GetAllTasksForProjectWithCompletedStatus(int projectId);
        List<Task> GetAllTasksForProjectWithUndefinedStatus();
        List<Task> GetAllTasksForProjectWithProcessingStatus();
        List<Task> GetAllTasksForProjectWithCompletedStatus();
        Task GetById(int tasikId);
        void Delete(Task model);
        List<Task> GetTaskByName(string filterTaskName, Enum.TaskStatusType completetd);
        List<Task> GetTaskByName(string filterTaskName);
        List<Task> GetProjectTasksByEmployeeQualification(List<EmployeeQualification> EmployeeQualifications, List<EmployeeProject> EmployeeProjects, IUnitOfWork uow, string project);
        List<Task> GetByProjectIdWithoutGeneralTasks(int projectId);
        List<Task> GetByGeneralProjectId(int projectId);
    }
}
