using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Qualification : EntityObject
    {
        public List<EmployeeQualification> EmployeeQualifications { get; set; }

        public string QualificationName { get; set; }
    }
}
