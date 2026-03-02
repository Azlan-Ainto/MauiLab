using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskSuite.Data;
using TaskSuite.Models;

namespace TaskSuite.Services
{
    public class ToDoService
    {
        private readonly AppDbContext _context;

        public ToDoService()
        {
            _context = new AppDbContext();
        }

        // Alle Einträge aus der Datenbank laden
        public async Task<List<ToDoItem>> GetItemsAsync()
        {
            return await _context.ToDoItems
                .AsNoTracking() // Verbessert die Performance beim reinen Lesen
                .ToListAsync();
        }

        // Einen einzelnen Eintrag anhand der ID finden
        public async Task<ToDoItem?> GetItemByIdAsync(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        // Speichern: Erkennt automatisch, ob neu (Add) oder Update
        public async Task SaveItemAsync(ToDoItem item)
        {
            if (item.Id == 0)
            {
                // Neuer Eintrag
                _context.ToDoItems.Add(item);
            }
            else
            {
                // Bestehender Eintrag wird aktualisiert
                _context.Entry(item).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        // Löschen eines Eintrags
        public async Task DeleteItemAsync(ToDoItem item)
        {
            _context.ToDoItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
