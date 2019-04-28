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
            return _dbContext.Department.OrderBy(p=>p.DeptName).ToList();
        }

        public void Add(Department model)
        {
            _dbContext.Department.Add(model);
        }

        public void Delete(Department model)
        {
            _dbContext.Department.Remove(model);
        }

        public Department GetById(int departmentId)
        {
            return _dbContext.Department.Where(d => d.Id == departmentId).FirstOrDefault();
        }

        public List<Department> GetAllWithoutThisDepartmentId(int departmentId)
        {
            return _dbContext.Department.Where(p=>p.Id != departmentId).OrderBy(p => p.DeptName).ToList();
        }
    }
}
