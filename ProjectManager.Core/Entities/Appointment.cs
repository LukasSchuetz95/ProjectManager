using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Core.Entities
{
    public class Appointment : EntityObject
    {
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Termin")]
        public string AppoName { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Termintyp")]
        public string AppoType { get; set; }

        public string Information { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Von")]
        public DateTime Startdate { get; set; }

        [Display(Name = "Bis")]
        public DateTime Enddate { get; set; }

    }
}
