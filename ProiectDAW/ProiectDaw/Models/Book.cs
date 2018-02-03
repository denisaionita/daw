using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class Book
    {
        [Key]
        public string BookId { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }

    }
}
