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

        [Required(ErrorMessage = "This field is required")]
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
            throw new NotImplementedException();
        }
    }
}
