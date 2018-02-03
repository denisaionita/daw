using Microsoft.EntityFrameworkCore;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("server=tcp:denisa-daw.database.windows.net;database=denisa;user=denisa;password=ionitaDen1!");
        }
    }
}
