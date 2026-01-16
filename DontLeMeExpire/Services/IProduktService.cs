using DontLeMeExpire.Models;

namespace DontLeMeExpire.Services
{
    public interface IProduktService
    {
        Task<IEnumerable<Produkt>> FindeProdukteNachLagerort(string aufbewahrungsort);
        Task<IEnumerable<Produkt>> LadeAbgelaufeneProdukte();
        Task<IEnumerable<Produkt>> LadeProdukteBaldAblaufen(int tage = 5);
        Task<IEnumerable<Produkt>> LadeProdukteHeuteAblaufen();
        Task<IEnumerable<Produkt>> LadeProduktliste();
        Task<Produkt?> LadeProduktNachId(string id);
        Task LoescheAlleProdukte();
        Task LoescheProdukt(Produkt produkt);
        Task SpeichereProdukt(Produkt produkt);
    }
}