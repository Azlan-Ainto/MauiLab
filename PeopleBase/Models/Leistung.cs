namespace PeopleBase.Models
{
    public class Leistung
    {
        public string AbrechnungsCode { get; set; }= string.Empty;
        public string Bezeichnung { get; set; } = string.Empty;
        public decimal Betrag { get; set; }
        public DateTime Datum { get; set; }
    }
}