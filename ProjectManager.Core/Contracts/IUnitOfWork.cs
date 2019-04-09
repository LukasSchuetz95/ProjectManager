using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }

        IDepartmentRepository Departments { get; }

        IEmployeeQualificationRepository EmployeeQualifications { get; }

        IEmployeeRepository Employees { get; }

        IEmployeeTaskRepository EmployeeTasks { get; }

        IProjectRepository Projects { get; }

        IQualificationRepository Qualifications { get; }

        ITaskRepository Tasks { get; }

        ITaskQualificationRepository TaskQualifications { get; }

        IEmployeeProjectRepository EmployeeProjects { get; }

        IDashboardDisplayRepository DashboardDisplays { get; }


        void Save();

        void DeleteDatabase();

        void MigrateDatabase();

        void FillDb();
    }
}
