using ProjectManager.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Project : EntityObject, IValidatableObject
    {
        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Projektname")]
        public string ProjectName { get; set; }

        public ProjectStatusType Status { get; set; }

        public string Information { get; set; }

        //[Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Von")]
        public DateTime? Startdate { get; set; }

        [Display(Name = "Bis")]
        public DateTime? Enddate { get; set; }

        [Display(Name = "Geschätzte Zeit")]
        public string ValuedTime { get; set; }

        public DateTime? Deadline { get; set; }

        public override string ToString()
        {
            return Status.ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if((this.Startdate!=null) && (this.Enddate!=null))
            {
                if(this.Startdate > this.Enddate)
                {
                    yield return new ValidationResult("Startdatum muss vor Enddatum liegen !", new List<string>() { nameof(this.Startdate), nameof(this.Enddate) });
                }
                if (this.Startdate >= DateTime.Now)
                {
                    yield return new ValidationResult("Startdatum muss vor aktuellem Datum liegen !", new List<string>() { nameof(this.Startdate) });
                }
            }
        }
    }
}
