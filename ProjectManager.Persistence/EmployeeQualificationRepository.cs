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
            return _dbContext.EmployeeQualification.Include(e => e.Employee).Include(q => q.Qualification).Where(e => e.Qualification.QualificationName == "Project Manager").ToList();
        }

        public List<EmployeeQualification> GetQualificationsByEmployeeId(int employeeId)
        {
            return _dbContext.EmployeeQualification.Include(p=>p.Qualification).Include(p=>p.Employee).Where(e => e.EmployeeId == employeeId).ToList();
        }

        public List<EmployeeQualification> GetEmployeesByQualifications(int qualificationId)
        {
            return _dbContext.EmployeeQualification.Include(p => p.Employee).Include(p => p.Qualification).Where(p=>p.QualificationId == qualificationId).ToList();
        }

        public List<EmployeeQualification> GetAllProjectManagersAndProjectMembers(int projectId)
        {
            List<EmployeeQualification> projectManagers = _dbContext.EmployeeQualification.Include(e => e.Employee).Include(q => q.Qualification).
                Where(e => e.Qualification.QualificationName == "Project Manager").ToList();

            List<EmployeeProject> employeeProjects = _dbContext.EmployeeProject.Where(p => p.ProjectId == projectId).ToList();

            List<EmployeeQualification> employees = new List<EmployeeQualification>();

            foreach (var pm in projectManagers)
            {
                foreach (var ep in employeeProjects)
                {
                    if (pm.EmployeeId == ep.EmployeeId)
                    {
                        employees.Add(pm);
                    }
                }
            }

            return employees;
        }
    }
}
