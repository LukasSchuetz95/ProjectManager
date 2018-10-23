using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Project : EntityObject
    {
        public List<Task> Tasks { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Projektname")]
        public string ProjectName { get; set; }

        public string Status { get; set; }

        public string Information { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Von")]
        public DateTime Startdate { get; set; }

        [Display(Name = "Bis")]
        public DateTime Enddate { get; set; }

        [Display(Name = "Geschätzte Zeit")]
        public string ValuedTime { get; set; }

        public DateTime Deadline { get; set; }
    }
}
