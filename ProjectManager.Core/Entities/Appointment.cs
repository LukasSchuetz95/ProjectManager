using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Core.Entities
{
    public class Appointment : EntityObject
    {
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        public string AppoName { get; set; }
        public string AppoType { get; set; }
        public string Information { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }

    }
}
