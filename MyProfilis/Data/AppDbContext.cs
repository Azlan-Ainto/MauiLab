using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyProfilis.Models;


namespace MyProfilis.Data
{
  


    public class AppDbContext : DbContext
    {
        public DbSet<Person> Personen => Set<Person>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.ID);
                entity.Property(p => p.Vorname).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Nachname).IsRequired().HasMaxLength(100);
            });
        }
    }
}
