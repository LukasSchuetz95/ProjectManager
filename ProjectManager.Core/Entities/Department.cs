using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Department : EntityObject
    {
        public List<Employee> Employees { get; set; }

        public string DeptLocati { get; set; }

        public string DeptName { get; set; }
    }
}
