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
            builder.UseSqlServer("server=tcp:vlad-daw.database.windows.net;database=vlad;user=vlad;password=Parola123!");
        }
    }
}
