using System;
using System.Collections.Generic;
using System.Text;

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

        IUserRepository Users { get; }


        void Save();

        void DeleteDatabase();

        void MigrateDatabase();

        void FillDb();
    }
}
