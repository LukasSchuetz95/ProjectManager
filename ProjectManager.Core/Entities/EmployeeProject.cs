using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class EmployeeProject : EntityObject
    {
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }


        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        public int ProjectId { get; set; }

        [Display(Name = "Project Manager")]
        public bool Projectmanager { get; set; }
    }
}
