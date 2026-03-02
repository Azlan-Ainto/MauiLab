using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleBase.Models
{
    public class Behandlungsfall
    {
        public Guid Id { get; set; }
        public DateTime Beginn { get; set; }
        public DateTime? Ende { get; set; }

        public ICollection<Diagnose>? Diagnosen { get; set; }
        public ICollection<Leistung>? Leistungen { get; set; }
        public ICollection<Medikation>? Medikationen { get; set; }
    }
}
