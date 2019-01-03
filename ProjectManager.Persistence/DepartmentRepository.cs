using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Persistence
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public DepartmentRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Department> GetAll()
        {
            return _dbContext.Departments.OrderBy(p=>p.DeptName).ToList();
        }
    }
}
