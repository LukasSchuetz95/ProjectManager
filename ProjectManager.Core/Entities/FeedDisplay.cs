using ProjectManager.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.Entities
{
    public class FeedDisplay : EntityObject, IValidatableObject
    {

        public Employee Employee { get; set; }

        public Appointment Appointment { get; set; }

        public Task Task { get; set; }

        public DateTime? Startdatum { get; set; }

        public bool Finished { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
