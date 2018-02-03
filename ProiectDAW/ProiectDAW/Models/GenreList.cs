using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class GenreList
    {
        [Key]
        public string Id { get; set; }

        public string BookGenre { get; set; }
        public string BookISBN { get; set; }

    }
}
