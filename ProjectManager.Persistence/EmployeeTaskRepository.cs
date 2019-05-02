using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Persistence
{
    public class EmployeeTaskRepository : IEmployeeTaskRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public EmployeeTaskRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(EmployeeTask model)
        {
            _dbContext.EmployeeTask.Add(model);
        }

        public void Delete(EmployeeTask model)
        {
            _dbContext.EmployeeTask.Remove(model);
        }


        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <returns></returns>
        public List<EmployeeTask> GetAll()
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(t => t.Task).OrderBy(p => p.Task.Status).ToList();
        }


        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>     
        public EmployeeTask GetByEmployeeIdAndTaskId(int empId, int taskId)
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(t => t.Task).SingleOrDefault(p => p.EmployeeId == empId && p.TaskId == taskId);
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="empProId"></param>
        /// <returns></returns>
        public EmployeeTask GetById(int empProId)
        {
            return _dbContext.EmployeeTask.Where(p => p.Id == empProId).FirstOrDefault();
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public EmployeeTask GetByProjectId(int projectId)
        {
            return _dbContext.EmployeeTask.SingleOrDefault(e => e.Task.ProjectId == projectId);
        }


        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public EmployeeTask GetByTaskId(int taskId)
        {
            return _dbContext.EmployeeTask.SingleOrDefault(e => e.Id == taskId);
        }


        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>

        public EmployeeTask GetEmployeeTaskByTaskId(int taskId)
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(t => t.Task).Where(t => t.TaskId == taskId).LastOrDefault();
        }

        public void Update(EmployeeTask model)
        {
            _dbContext.EmployeeTask.Update(model);
        }

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        public List<EmployeeTask> GetAllByEmployeeId(int Id)
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(t => t.Task).
                   Where(et => et.EmployeeId == Id && et.Task.Status == Core.Enum.TaskStatusType.Open &&
                                                      et.Picked == false).
                   OrderBy(et => et.Task.TaskName).ToList();
        }

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        public List<EmployeeTask> GetTasksWithHighPriority(int Id)
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(e => e.Task).
                   Where(et => et.EmployeeId == Id && et.Task.Status == Core.Enum.TaskStatusType.Open &&
                   et.Task.Priority == Core.Enum.PriorityType.High &&
                   et.Picked == false &&
                   et.PassedTask.Id != Id).ToList();
        }

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        public List<EmployeeTask> GetAllExceptFromEmployeeId(int employeeId)
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(e => e.Task).Where(p => p.EmployeeId != employeeId && p.Picked == true).ToList();
        }


        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>

        public List<EmployeeProject> GetAllByProjectId(int projectId)
        {
            return _dbContext.EmployeeProject.Include(e => e.Employee).Include(p => p.Project)
                .Where(p => p.ProjectId == projectId).OrderBy(e => e.Id).ToList();
        }

        /// <summary>
        /// Manuel Mairinger Created
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>

        public List<Employee> GetAllWithProjectID(int projectId, int taskId)
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
    }
}
