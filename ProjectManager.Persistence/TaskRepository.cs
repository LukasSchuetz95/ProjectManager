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

        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <returns></returns>

        public List<Task> GetAll()
        {
            return _dbContext.Task.Include(ord => ord.Project).OrderBy(ord => ord.Project).ToList();
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<Task> GetAllTasksForProjectWithCompletedStatus(int projectId)
        {
            return _dbContext.Task.Where(p => (p.ProjectId == projectId) && (p.Status == TaskStatusType.Completed)).ToList();
        }


        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <returns></returns>

        public List<Task> GetAllTasksForProjectWithCompletedStatus()
        {
            return _dbContext.Task.Where(p=> p.Status == TaskStatusType.Completed).ToList();
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<Task> GetAllTasksForProjectWithProcessingStatus(int projectId)
        {
            return _dbContext.Task.Where(p => (p.ProjectId == projectId) && (p.Status == TaskStatusType.Processing)).ToList();
        }


        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <returns></returns>
        public List<Task> GetAllTasksForProjectWithProcessingStatus()
        {
            return _dbContext.Task.Where(p => p.Status == TaskStatusType.Processing).ToList();
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<Task> GetAllTasksForProjectWithUndefinedStatus(int projectId)
        {
            return _dbContext.Task.Where(p => (p.ProjectId == projectId) && (p.Status == TaskStatusType.Open)).ToList();
        }


        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <returns></returns>
        public List<Task> GetAllTasksForProjectWithUndefinedStatus()
        {
            return _dbContext.Task.Where(p => p.Status == TaskStatusType.Open).ToList();
        }


        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <param name="tasikId"></param>
        /// <returns></returns>
        public Task GetById(int tasikId)
        {
            return _dbContext.Task.Where(t => t.Id == tasikId).FirstOrDefault();
        }


        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Task> GetTaskByName(string filter, TaskStatusType status)
        {
     
            IQueryable<Task> query = _dbContext.Task.Where(t => t.Status == status);

            if (filter == null || filter == "")
            {
                return query.Where(t => t.Status == status).ToList();

            }
            else
            {
                return query.Where(p => p.TaskName.Contains(filter)).ToList();

            }   

        }


        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <param name="filterTaskName"></param>
        /// <returns></returns>
        public List<Task> GetTaskByName(string filterTaskName)
        {
            IQueryable<Task> query = _dbContext.Task.OrderBy(p => p.TaskName);


            if (filterTaskName == null || filterTaskName == "")
            {
                return query.ToList();
            }
            else
            {
                return query.Where(p => p.TaskName.Contains(filterTaskName)).ToList();
            }
        }



        public void Update(Task task)
        {
            _dbContext.Task.Update(task);
        }

        #region Dashboard

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        public List<Task> GetProjectTasksByEmployeeQualification(List<EmployeeQualification> EmployeeQualifications,
                                                                 List<EmployeeProject> EmployeeProjects,
                                                                 IUnitOfWork uow, string project)
        {

            List<TaskQualification> taskQualifications = new List<TaskQualification>();
            List<Task> projectTasks = new List<Task>();
            List<Task> poolTasks = new List<Task>();

            taskQualifications = GetAllQualifications(EmployeeQualifications, uow);

            projectTasks = GetAllProjectTasks(EmployeeProjects, uow, project);

            return poolTasks = GetMatchingTasks(taskQualifications, projectTasks);
        }

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        public List<Task> GetByGeneralProjectId(int projectId)
        {
            return _dbContext.Task.Where(p => p.ProjectId == projectId && p.Project.ProjectName == "General" && p.Status == TaskStatusType.Open).OrderBy(p => p.TaskName).ToList();
        }

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        public List<Task> GetByProjectIdWithoutGeneralTasks(int projectId)
        {
            return _dbContext.Task.Where(p => p.ProjectId == projectId && p.Project.ProjectName != "General" && p.Status == TaskStatusType.Open).OrderBy(p => p.TaskName).ToList();
        }

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        private List<TaskQualification> GetAllQualifications(List<EmployeeQualification> EmployeeQualifications, IUnitOfWork uow)
        {
            List<TaskQualification> taskQualifications = new List<TaskQualification>();

            foreach (var ele in EmployeeQualifications)
            {
                taskQualifications.AddRange(uow.TaskQualifications.GetByQualificationId(ele.Qualification.Id));
            }

            return taskQualifications;
        }

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        private List<Task> GetAllProjectTasks(List<EmployeeProject> EmployeeProjects, IUnitOfWork uow, string project)
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

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        private List<Task> GetMatchingTasks(List<TaskQualification> taskQualifications, List<Task> projectTasks)
        {
            List<Task> poolTasks = new List<Task>();
            bool check = true;

            foreach (var ele in taskQualifications)
            {
                foreach (var obj in projectTasks)
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
