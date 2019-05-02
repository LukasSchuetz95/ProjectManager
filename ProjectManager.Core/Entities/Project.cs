using ProjectManager.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Project : EntityObject
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Project name")]
        public string ProjectName { get; set; }

        public ProjectStatusType Status { get; set; }

        public string Information { get; set; }

        [Display(Name = "From")]
        [DataType(DataType.Date)]
        public DateTime? Startdate { get; set; }

        [Display(Name = "To")]
        [DataType(DataType.Date)]
        public DateTime? Enddate { get; set; }

        [Display(Name = "Valued Time (in Hours)")]
        public string ValuedTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Deadline { get; set; }

        public override string ToString()
        {
            return Status.ToString();
        }
    }
}
