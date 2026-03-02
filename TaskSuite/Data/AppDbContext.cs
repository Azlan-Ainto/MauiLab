using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskSuite.Models;

namespace TaskSuite.Data
{
    public class AppDbContext : DbContext
    {
        // Unsere Tabelle für die ToDo-Einträge
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public AppDbContext()
        {
            // Erstellt die Datenbank automatisch, falls sie noch nicht existiert
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verbindung zur SQLite-Datei herstellen
            optionsBuilder.UseSqlite($"Data Source={DatabaseConstants.DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- Fluent API Konfiguration ---

            // Primärschlüssel festlegen
            modelBuilder.Entity<ToDoItem>()
                .HasKey(t => t.Id);

            // Titel ist ein Pflichtfeld und darf max. 200 Zeichen haben
            modelBuilder.Entity<ToDoItem>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            // MarkerColor Standardwert setzen
            modelBuilder.Entity<ToDoItem>()
                .Property(t => t.MarkerColor)
                .HasDefaultValue("Transparent");

            // Enums als Strings oder Integer speichern? 
            // Hier nutzen wir Integer (Standard), was für die Performance super ist.
            modelBuilder.Entity<ToDoItem>()
                .Property(t => t.Status)
                .IsRequired();

            modelBuilder.Entity<ToDoItem>()
                .Property(t => t.Category)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
