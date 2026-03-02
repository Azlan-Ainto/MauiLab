using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleBase.Models
{
    public class Kontakt
    {
        public string Telefon { get; set; } = string.Empty;
        public string Mobil { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string NotfallkontaktName { get; set; } = string.Empty;
        public string NotfallkontaktTelefon { get; set; } = string.Empty;
    }
}
