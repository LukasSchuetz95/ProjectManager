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

        public List<EmployeeTask> GetAll()
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(t => t.Task).OrderBy(p => p.Task.Status).ToList();
        }

        public EmployeeTask GetByEmployeeIdAndTaskId(int taskId, int empId)
        {
            return _dbContext.EmployeeTask.SingleOrDefault(p => p.EmployeeId == empId && p.TaskId == taskId);
        }

        public EmployeeTask GetById(int empProId)
        {
            return _dbContext.EmployeeTask.Where(p => p.Id == empProId).FirstOrDefault();
        }

        public EmployeeTask GetByProjectId(int projectId)
        {
            return _dbContext.EmployeeTask.SingleOrDefault(e => e.Task.ProjectId == projectId);
        }

        public EmployeeTask GetByTaskId(int taskId)
        {
            return _dbContext.EmployeeTask.SingleOrDefault(e => e.Id == taskId);
        }

        public EmployeeTask GetEmployeeTaskByTaskId(int taskId)
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(t => t.Task).Where(t => t.TaskId == taskId).SingleOrDefault();
        }

        public void Update(EmployeeTask model)
        {
            _dbContext.EmployeeTask.Update(model);
        }

        public List<EmployeeTask>GetAllByEmployeeId(int Id)
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(t => t.Task).
                   Where(et => et.EmployeeId == Id && et.Task.Status==Core.Enum.TaskStatusType.NichtBegonnen && et.Picked==false).
                   OrderBy(et => et.Task.TaskName).ToList();
        }

        public List<EmployeeTask>GetTasksWithHighPriority(int Id)
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(e => e.Task).
                   Where(et => et.EmployeeId == Id && et.Task.Status == Core.Enum.TaskStatusType.NichtBegonnen &&
                   et.Task.Priority == Core.Enum.PriorityType.Hoch).ToList();
        }

        public List<EmployeeTask>GetAllExceptFromEmployeeId(int employeeId)
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(e => e.Task).Where(p => p.EmployeeId != employeeId).ToList();
        }
    }
}
