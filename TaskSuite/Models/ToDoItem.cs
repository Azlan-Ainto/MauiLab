using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSuite.Models
{
    

        public class ToDoItem
        {
            public int Id { get; set; } // Primärschlüssel für die Datenbank
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;

            // Datum und Uhrzeit trennen wir, da MAUI dafür eigene UI-Elemente 
            // (DatePicker und TimePicker) hat.
            public DateTime StartDate { get; set; }
            public TimeSpan StartTime { get; set; }
            public DateTime EndDate { get; set; }
            public TimeSpan EndTime { get; set; }
            public ToDoStatus Status { get; set; } = ToDoStatus.NichtAngefangen;
            public ToDoCategory Category { get; set; } = ToDoCategory.Sonstiges;
            // Für die farbliche Markierung speichern wir einen Hex-Code als Text (z.B. "#FF0000" für Rot).
            // SQLite kann keine MAUI-Farbobjekte direkt speichern, daher der Weg über den String.
            public string MarkerColor { get; set; } = "Transparent";
        }
    
}
