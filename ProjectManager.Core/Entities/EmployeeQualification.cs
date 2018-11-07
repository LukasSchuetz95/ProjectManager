using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class EmployeeQualification : EntityObject
    {
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(QualificationId))]
        public Qualification Qualification { get; set; }
        public int QualificationId { get; set; }


        public string Information { get; set; }

        [Display(Name = "Skill-Level")]
        public int SkillLevel { get; set; }
    }
}
