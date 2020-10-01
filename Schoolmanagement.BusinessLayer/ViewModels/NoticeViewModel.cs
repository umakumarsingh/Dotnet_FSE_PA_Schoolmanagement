using Schoolmanagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schoolmanagement.BusinessLayer.ViewModels
{
    public class NoticeViewModel
    {
        public string Name { get; set; }
        [Display(Name = "Notice Date")]
        public DateTime NoticeDate { get; set; }
        [Display(Name = "Notice For")]
        public ClassList classList { get; set; }
        public string Event { get; set; }
        [Display(Name = "Chief Guest")]
        public string ChiefGuest { get; set; }
        public string Remarks { get; set; }
    }
}
