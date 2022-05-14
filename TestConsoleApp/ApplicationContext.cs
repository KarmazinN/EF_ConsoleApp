using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestConsoleApp.Models;

namespace TestConsoleApp
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestConseleAppdb;Trusted_Connection=True;");
        }

    }
}
