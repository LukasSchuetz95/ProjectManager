using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Task : EntityObject
    {
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        public int ProjectId { get; set; }


        public string TaskName { get; set; }

        public int Priority { get; set; }

        public string Status { get; set; }

        public bool FixedTask { get; set; }

        public string Information { get; set; }

        public DateTime Startdate { get; set; }

        public DateTime Enddate { get; set; }

        public string ValuedTime { get; set; }

        public DateTime Deadline { get; set; }
    }
}
