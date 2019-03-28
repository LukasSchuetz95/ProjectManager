using ProjectManager.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Qualification : EntityObject
    {

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Qualification")]
        public string QualificationName { get; set; }

        public override string ToString()
        {
            return QualificationName;
        }
    }
}
