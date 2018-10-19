using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Department : EntityObject
    {
        public List<Employee> Employee { get; set; }

        public string DeptLocation { get; set; }

        public string DeptName { get; set; }
    }
}
