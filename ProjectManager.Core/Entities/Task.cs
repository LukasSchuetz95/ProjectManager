using ProjectManager.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Task : EntityObject, IValidatableObject
    {

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        public int ProjectId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Display(Name = "Priority")]
        public PriorityType Priority { get; set; }

        public TaskStatusType Status { get; set; }

        [Display(Name = "Fixed Task")]
        public bool FixedTask { get; set; }

        public string Information { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "From")]
        public DateTime Created { get; set; }

        [Display(Name = "To")]
        public DateTime? Enddate { get; set; }

        [Display(Name = "Valued Time")]
        public string ValuedTime { get; set; }

        public DateTime? Deadline { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((this.Created != null) && (this.Enddate != null))
            {
                if (this.Created > this.Enddate)
                {
                    yield return new ValidationResult("Start date has to be before end date !", new List<string>() { nameof(this.Created), nameof(this.Enddate) });
                }
                if (this.Created > DateTime.Now)
                {
                    yield return new ValidationResult("Start date has to be before the current date !", new List<string>() { nameof(this.Created) });
                }
            }
        }
    }
}
