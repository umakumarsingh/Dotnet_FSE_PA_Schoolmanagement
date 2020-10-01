using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schoolmanagement.BusinessLayer.ViewModels
{
    public class TeacherViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public long PhoneNumber { get; set; }
        public string Subject { get; set; }
        public int Experience { get; set; }
        public string Remark { get; set; }
    }
}
