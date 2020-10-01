using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schoolmanagement.BusinessLayer.ViewModels
{
    public class LibraryViewModel
    {
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        public string Publication { get; set; }
        public string Writer { get; set; }
        public int Stock { get; set; }
    }
}
