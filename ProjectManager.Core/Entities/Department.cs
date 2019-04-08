using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Department : EntityObject
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Department Location")]
        public string DeptLocation { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }
    }
}
