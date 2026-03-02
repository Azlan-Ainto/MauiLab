using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleBase.Models
{
    public class Personendaten
    {
        public int Id { get; set; }
        public string Vorname { get; set; } = string.Empty;
        public string Nachname { get; set; } = string.Empty;
        public DateTime Geburtsdatum { get; set; } = DateTime.MinValue;
        public int Alter { get; set; }
    }
}
