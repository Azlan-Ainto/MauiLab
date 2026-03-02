using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleBase.Models
{
    public class Versicherung
    {
        public string Typ { get; set; } // Gesetzlich / Privat
        public string Krankenkasse { get; set; }
        public bool Zuzahlungsbefreit { get; set; }
    }
}
