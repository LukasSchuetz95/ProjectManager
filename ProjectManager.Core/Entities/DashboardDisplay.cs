using ProjectManager.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.Entities
{
    public class DashboardDisplay : EntityObject, IValidatableObject
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public DateTime Startdatum { get; set; }

        public bool Finished { get; set; }

        public string SpecificInformation { get; set; }

        public int EmployeeId { get; set; }

        public int AppointmentId { get; set; }

        public int TaskId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
