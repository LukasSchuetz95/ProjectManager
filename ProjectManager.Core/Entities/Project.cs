using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Project : EntityObject
    {
        public List<Task> Tasks { get; set; }

        public string ProjectName { get; set; }

        public string Status { get; set; }

        public string Information { get; set; }

        public DateTime Startdate { get; set; }

        public DateTime Enddate { get; set; }

        public string ValuedTime { get; set; }

        public DateTime Deadline { get; set; }
    }
}
