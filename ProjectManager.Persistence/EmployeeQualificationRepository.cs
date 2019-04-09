using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Persistence
{
    public class EmployeeQualificationRepository : IEmployeeQualificationRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public EmployeeQualificationRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public List<EmployeeQualification> GetAllProjectManagers()
        {
            return _dbContext.EmployeeQualification.Include(e => e.Employee).Include(q => q.Qualification).Where(e => e.Qualification.QualificationName == "Projekt Manager").ToList();
        }

        public List<EmployeeQualification> GetQualificationsByEmployeeId(int employeeId)
        {
            return _dbContext.EmployeeQualification.Include(p=>p.Qualification).Include(p=>p.Employee).Where(e => e.EmployeeId == employeeId).ToList();
        }

        public List<Employee> GetEmployeesByQualifications(List<TaskQualification> taskQualifications)
        {
            List<Employee> employees = new List<Employee>();

            foreach (var tQ in taskQualifications)
            {
                employees.AddRange(_dbContext.EmployeeQualification.Include(p => p.Employee).Include(p => p.Qualification).Where(p=>p.Qualification == tQ.Qualification).ToList());
            }
            return employees;
        }
    }
}
