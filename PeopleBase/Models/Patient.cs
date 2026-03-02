using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleBase.Models
{
    /// <summary>
    /// die Patientenklasse ist die Klasse, die die Patienten repräsentiert. 
    /// Sie enthält alle Informationen über die Patienten, wie z.B. Name, Alter, Geschlecht, etc.
    public class Patient
    {
        public Guid Id { get; set; }
        public string Versichertennummer { get; set; } = string.Empty;

        public Personendaten? Personendaten { get; set; } 
        public Kontakt? Kontakt { get; set; }
        public Versicherung? Versicherung { get; set; }

        public ICollection<Diagnose>? Diagnosen { get; set; }
        public ICollection<Termin>? Termine { get; set; }
        public ICollection<Medikation>? Medikationen { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }


    }
}
