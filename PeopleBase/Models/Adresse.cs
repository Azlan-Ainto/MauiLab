using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleBase.Models
{
    public class Adresse
    {
        public string Strasse { get; set; } = string.Empty;
        public string Hausnummer { get; set; } = string.Empty ;

        public string PLZ { get; set; } = string.Empty;
        public string Ort { get; set; } = string.Empty;
    }
}
