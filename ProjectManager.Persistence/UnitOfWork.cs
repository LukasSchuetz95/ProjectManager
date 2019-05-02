using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectManager.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContextPersistence _dbContext;
        private bool _disposed;

        public IAppointmentRepository Appointments { get; }

        public IDepartmentRepository Departments { get; }

        public IEmployeeRepository Employees { get; }

        public IEmployeeQualificationRepository EmployeeQualifications { get; }

        public IEmployeeTaskRepository EmployeeTasks { get; }

        public IProjectRepository Projects { get; }

        public IQualificationRepository Qualifications { get; }

        public ITaskRepository Tasks { get; }

        public IEmployeeProjectRepository EmployeeProjects { get; }

        public ITaskQualificationRepository TaskQualifications { get; }

        public IDashboardDisplayRepository DashboardDisplays { get; }

        public UnitOfWork()
        {
            _dbContext = new ApplicationDbContextPersistence();
            Appointments = new AppointmentRepository(_dbContext);
            Departments = new DepartmentRepository(_dbContext);
            Employees = new EmployeeRepository(_dbContext);
            EmployeeQualifications = new EmployeeQualificationRepository(_dbContext);
            EmployeeTasks = new EmployeeTaskRepository(_dbContext);
            Projects = new ProjectRepository(_dbContext);
            Qualifications = new QualificationRepository(_dbContext);
            Tasks = new TaskRepository(_dbContext);
            TaskQualifications = new TaskQualificationRepository(_dbContext);
            EmployeeProjects = new EmployeeProjectRepository(_dbContext);
            DashboardDisplays = new DashboardDisplayRepository(_dbContext);
        }

        public void DeleteDatabase()
        {
            _dbContext.Database.EnsureDeleted();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
        }

        public void FillDb()
        {
            this.DeleteDatabase();
            this.MigrateDatabase();
            
            Save();
        }

        public void MigrateDatabase()
        {
            try
            {
                _dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Save()
        {
            var entities = _dbContext.ChangeTracker.Entries()
               .Where(entity => entity.State == EntityState.Added
                                || entity.State == EntityState.Modified)
               .Select(e => e.Entity);
            foreach (var entity in entities)
            {
                ValidateEntity(entity);
            }
            _dbContext.SaveChanges();
        }

        private void ValidateEntity(object entity)
        {
            if(entity is Qualification qualification)
            {
                if(_dbContext.Qualification.Any(q => (q.QualificationName.ToUpper() == qualification.QualificationName.ToUpper()) && (q.Id != qualification.Id)))
                {
                    throw new ValidationException(new ValidationResult($"There is already a Qualification with the Name: {qualification.QualificationName}", 
                        new List<string>() { nameof(qualification.QualificationName) }), null, null);
                }
            }
            else if (entity is Department department)
            {
                if (_dbContext.Department.Any(d=> d.DeptName.ToUpper() == department.DeptName.ToUpper()))
                {
                    throw new ValidationException();
                }
            }
            else if (entity is EmployeeTask employeeTask)
            {
                if (_dbContext.EmployeeTask.Any(d => (d.TaskId == employeeTask.TaskId) &&
                                                     (d.EmployeeId == employeeTask.EmployeeId) &&
                                                     (d.Id != employeeTask.Id) ))
                {
                    throw new ValidationException();
                }
                else if (employeeTask == null)
                {
                    throw new ValidationException();
                }
            }
            else if (entity is DashboardDisplay dashboardDisplay)
            {
                if (dashboardDisplay.TaskId == 0)
                {
                    if (_dbContext.DashboardDisplay.Any(d => ((d.EmployeeId == dashboardDisplay.EmployeeId &&
                                                               d.AppointmentId == dashboardDisplay.AppointmentId))))
                    {
                        throw new ValidationException();
                    }
                }
                else if (dashboardDisplay.AppointmentId == 0)
                {
                    if (_dbContext.DashboardDisplay.Any(d => (d.EmployeeId == dashboardDisplay.EmployeeId &&
                                                              d.TaskId == dashboardDisplay.TaskId)))
                    {
                        throw new ValidationException();
                    }
                }                
                else if (dashboardDisplay == null)
                {
                    throw new ValidationException();
                }
            }
        }

    }
}
