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
    }
}
