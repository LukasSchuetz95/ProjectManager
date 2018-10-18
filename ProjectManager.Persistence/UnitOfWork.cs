using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _dbContext;

        public IAppointmentRepository Appointments { get; }

        public IDepartmentRepository Departments { get; }

        public IEmployeeQualificationRepository EmployeeQualifications { get; }

        public IEmployeeRepository Employees { get; }

        public IProjectRepository Projects { get; }

        public IQualificationRepository Qualifications { get; }

        public ITaskRepository Tasks { get; }

        public IUserRepository Users { get; }

        public UnitOfWork()
        {
            _dbContext = new ApplicationDbContext();
            Appointments = new AppointmentRepository(_dbContext);
            Departments = new DepartmentRepository(_dbContext);
            EmployeeQualifications = new EmployeeQualificationRepository(_dbContext);
            Employees = new EmployeeRepository(_dbContext);
            Projects = new ProjectRepository(_dbContext);
            Qualifications = new QualificationRepository(_dbContext);
            Tasks = new TaskRepository(_dbContext);
            Users = new UserRepository(_dbContext);
        }

        public void DeleteDatabase()
        {
            _dbContext.Database.EnsureDeleted();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void FillDb()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

    }
}
