using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleBase.Models
{
    public class Termin
    {
        public DateTime Start { get; set; }
        public DateTime Ende { get; set; }
        public string Status { get; set; } = string.Empty; 
        public string Notiz { get; set; } = string.Empty;
    }
}
