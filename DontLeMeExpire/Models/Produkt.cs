namespace DontLeMeExpire.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Produktname { get; set; }
        public DateTime Verfallsdatum { get; set; }

        // Aufbewahrungsort(Kühlschrank, Gefrierschrank, Vorratsschrank etc)
        public string LagerID { get; set; }
        public string Foto { get; set; }
        public decimal Menge { get; set; }


    }
}
