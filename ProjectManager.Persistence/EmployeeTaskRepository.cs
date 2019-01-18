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
            _dbContext.EmployeeTasks.Add(model);
        }

        public void Delete(EmployeeTask model)
        {
            _dbContext.EmployeeTasks.Remove(model);
        }

        public List<EmployeeTask> GetAll()
        {
            return _dbContext.EmployeeTasks.Include(e => e.Employee).Include(t => t.Task).OrderBy(p => p.Task.Status).ToList();     

            //throw new NotImplementedException();
        }

        public EmployeeTask GetByEmployeeIdAndTaskId(int taskId, int empId)
        {
            return _dbContext.EmployeeTasks.SingleOrDefault(p => p.EmployeeId == empId && p.TaskId == taskId);
        }

        public EmployeeTask GetById(int empProId)
        {
            return _dbContext.EmployeeTasks.Where(p => p.Id == empProId).FirstOrDefault();
        }

        public EmployeeTask GetByProjectId(int projectId) 
        {
            return _dbContext.EmployeeTasks.SingleOrDefault(e => e.Task.ProjectId == projectId);
        }

        public EmployeeTask GetByTaskId(int taskId)
        {
            return _dbContext.EmployeeTasks.SingleOrDefault(e => e.Id == taskId);
        }

        public EmployeeTask GetEmployeeTaskByTaskId(int taskId)
        {
            return _dbContext.EmployeeTasks.Include(e => e.Employee).Include(t => t.Task).Where(t => t.TaskId == taskId).SingleOrDefault();
        }

        public void Update(EmployeeTask model)
        {
            _dbContext.EmployeeTasks.Update(model);
        }

        public List<EmployeeTask> GetByEmployeeId(int employeeId)
        {
            return _dbContext.EmployeeTasks.Where(p => p.EmployeeId == employeeId).OrderBy(p => p.Employee.Lastname).ThenBy(p => p.Employee.Firstname).ToList();
        }
    }
}
