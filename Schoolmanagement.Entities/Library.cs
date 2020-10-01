using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schoolmanagement.Entities
{
    public class Library
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookId { get; set; }
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        public string Publication { get; set; }
        public string Writer { get; set; }
        public int Stock { get; set; }
    }
}
