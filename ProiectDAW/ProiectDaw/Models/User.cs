using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class User
    {
        [Key]
        public string EmailAddress { get; set; }

        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string ProfilePicture { get; set; }
    }
}
