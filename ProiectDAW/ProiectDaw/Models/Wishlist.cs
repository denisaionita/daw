using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace ProiectDAW.Models
{
    public class Wishlist
    {
        [Key]
        public string WishListId { get; set; }

        public string UserEmail { get; set; }
        public string BookId { get; set; }

    }
}
