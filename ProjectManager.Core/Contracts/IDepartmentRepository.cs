using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Contracts
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        void Add(Department model);
        Department GetById(int departmentId);
    }
}
