using MongoDB.Libmongocrypt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Schoolmanagement.BusinessLayer.ViewModels
{
    public class BookBorrowViewModel
    {
        public DateTime FromDate { get; set; }
        [Display(Name = "To Date")]
        public DateTime Todate { get; set; }
        //public bool Status { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Library Library { get; set; }
    }
}
