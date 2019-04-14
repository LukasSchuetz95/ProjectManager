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

        public EmployeeTask GetByEmployeeIdAndTaskId(int empId, int taskId)
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
                   Where(et => et.EmployeeId == Id && et.Task.Status==Core.Enum.TaskStatusType.NichtBegonnen &&
                                                      et.Picked==false && 
                                                      et.PassedTask.Id != Id).
                   OrderBy(et => et.Task.TaskName).ToList();
        }

        public List<EmployeeTask>GetTasksWithHighPriority(int Id)
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(e => e.Task).
                   Where(et => et.EmployeeId == Id && et.Task.Status == Core.Enum.TaskStatusType.NichtBegonnen &&
                   et.Task.Priority == Core.Enum.PriorityType.Hoch && 
                   et.Picked == false &&
                   et.PassedTask.Id != Id).ToList();
        }

        public List<EmployeeTask>GetAllExceptFromEmployeeId(int employeeId)
        {
            return _dbContext.EmployeeTask.Include(e => e.Employee).Include(e => e.Task).Where(p => p.EmployeeId != employeeId).ToList();
        }

        public List<EmployeeProject> GetAllByProjectId(int projectId)
        {
            return _dbContext.EmployeeProject.Include(e => e.Employee).Include(p => p.Project)
                .Where(p => p.ProjectId == projectId).OrderBy(e => e.Id).ToList();
        }


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
