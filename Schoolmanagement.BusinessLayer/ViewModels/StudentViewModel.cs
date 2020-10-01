using Schoolmanagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schoolmanagement.BusinessLayer.ViewModels
{
    public class StudentViewModel
    {
        public string Name { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        public long Phone { get; set; }
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [Display(Name = "Class List")]
        public ClassList? classList { get; set; }
        public string Section { get; set; }
    }
}
