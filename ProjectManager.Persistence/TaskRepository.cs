using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Persistence
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public TaskRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Task task)
        {
            _dbContext.Task.Add(task);
        }

        public void Delete(Task model)
        {
            _dbContext.Task.Remove(model);
        }

        public List<Task> GetAll()
        {
            return _dbContext.Task.Include(ord => ord.Project).OrderBy(ord => ord.Project).ToList();
        }

        public List<Task> GetAllTasksForProjectWithCompletedStatus(int projectId)
        {
            return _dbContext.Task.Where(p => (p.ProjectId == projectId) && (p.Status == TaskStatusType.Completed)).ToList();
        }

        public List<Task> GetAllTasksForProjectWithCompletedStatus()
        {
            return _dbContext.Task.Where(p=> p.Status == TaskStatusType.Completed).ToList();
        }

        public List<Task> GetAllTasksForProjectWithProcessingStatus(int projectId)
        {
            return _dbContext.Task.Where(p => (p.ProjectId == projectId) && (p.Status == TaskStatusType.Processing)).ToList();
        }

        public List<Task> GetAllTasksForProjectWithProcessingStatus()
        {
            return _dbContext.Task.Where(p => p.Status == TaskStatusType.Processing).ToList();
        }

        public List<Task> GetAllTasksForProjectWithUndefinedStatus(int projectId)
        {
            return _dbContext.Task.Where(p => (p.ProjectId == projectId) && (p.Status == TaskStatusType.Open)).ToList();
        }

        public List<Task> GetAllTasksForProjectWithUndefinedStatus()
        {
            return _dbContext.Task.Where(p => p.Status == TaskStatusType.Open).ToList();
        }

        public Task GetById(int tasikId)
        {
            return _dbContext.Task.Where(t => t.Id == tasikId).FirstOrDefault();
        }

        public List<Task> GetTaskByName(string filter)
        {
            IQueryable<Task> query = _dbContext.Task.OrderBy(p => p.TaskName);

            if (filter == null || filter == "")
            {
                return query.ToList();
            }
            else
            {
                return query.Where(p => p.TaskName.Contains(filter)).ToList();
            }
        }

        public void Update(Task task)
        {
            _dbContext.Task.Update(task);
        }

        //Methoden wurden wegen der Übersicht ausgelagert
        public List<Task> GetProjectTasksByEmployeeQualification(List<EmployeeQualification> EmployeeQualifications,
                                                                 List<EmployeeProject> EmployeeProjects, 
                                                                 IUnitOfWork uow, string project){

            List<TaskQualification> taskQualifications = new List<TaskQualification>();
            List<Task> tasks = new List<Task>();
            List<Task> poolTasks = new List<Task>();

            taskQualifications = GetAllQualifications(EmployeeQualifications, uow);

            tasks = GetAllProjectTasks(EmployeeProjects, uow, project);

            return poolTasks = GetMatchingTasks(taskQualifications, tasks);

        }

        public List<Task> GetByGeneralProjectId(int projectId) 
        {
            return _dbContext.Task.Where(p => p.ProjectId == projectId && p.Project.ProjectName == "Allgemein" && p.Status == TaskStatusType.Open).ToList();
        }

        public List<Task> GetByProjectIdWithoutGeneralTasks(int projectId)
        {
            return _dbContext.Task.Where(p => p.ProjectId == projectId && p.Project.ProjectName != "Allgemein" && p.Status == TaskStatusType.Open).ToList();
        }

        #region Methods

        private List<TaskQualification> GetAllQualifications(List<EmployeeQualification>EmployeeQualifications, IUnitOfWork uow)
        {
            List<TaskQualification> taskQualifications = new List<TaskQualification>();

            foreach (var ele in EmployeeQualifications)
            {
                taskQualifications.AddRange(uow.TaskQualifications.GetByQualificationId(ele.Qualification.Id));
            }

            return taskQualifications;
        }

        private List<Task> GetAllProjectTasks(List<EmployeeProject>EmployeeProjects, IUnitOfWork uow, string project)
        {
            List<Task> tasks = new List<Task>();

            if (project == "All")
            {
                foreach (var ele in EmployeeProjects)
                {
                    tasks.AddRange(uow.Tasks.GetByProjectIdWithoutGeneralTasks(ele.Project.Id));
                }
            }
            else if (project == "General")
            {
                foreach (var ele in EmployeeProjects)
                {
                    tasks.AddRange(uow.Tasks.GetByGeneralProjectId(ele.Project.Id));
                }
            }

            return tasks;

        }

        private List<Task> GetMatchingTasks(List<TaskQualification> taskQualifications, List<Task> tasks)
        {
            List<Task> poolTasks = new List<Task>();
            bool check = true;

            foreach (var ele in taskQualifications)
            {
                foreach (var obj in tasks)
                {
                    if (ele.Task.Id == obj.Id)
                    {
                        foreach (var item in poolTasks)
                        {
                            if (item.Id == obj.Id)
                            {
                                check = false;
                            }
                        }

                        if (check == true)
                        {
                            poolTasks.Add(obj);
                        }

                        check = true;
                    }
                }
            }

            return poolTasks;
        }
        #endregion
    }
}
