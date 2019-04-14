using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectManager.Core.Enum;

namespace ProjectManager.Core.Entities
{
    public class Appointment : EntityObject, IValidatableObject
    {

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        [Display(Name = "Appointment")]
        public string AppoName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Appointment Type")]
        public AppointmentType AppoType { get; set; }
        
        public string Information { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "From")]
        public DateTime Startdate { get; set; }

        [Display(Name = "To")]
        public DateTime Enddate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((this.Startdate != null) && (this.Enddate != null))
            {
                if (this.Startdate > this.Enddate)
                {
                    yield return new ValidationResult("Start date has to be before end date !", new List<string>() { nameof(this.Startdate), nameof(this.Enddate) });
                }
                //if (this.Startdate >= DateTime.Now)
                //{
                //    yield return new ValidationResult("Start date has to be before the current date !", new List<string>() { nameof(this.Startdate) });
                //}
            }
        }
    }
}
