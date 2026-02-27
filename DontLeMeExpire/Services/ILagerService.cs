using DontLeMeExpire.Models;

namespace DontLeMeExpire.Services
{
    public interface ILagerService
    {
        Task<IEnumerable<Aufbewahrungsort>> LadeAufbewahrungsorte();
        Task<IEnumerable<AufbewahrungsortMitMenge>> HoleMitArtikelMengeAsync();
        Task<Aufbewahrungsort?> LadeAufbewahrungsortNachId(string id);
        Task LoescheAlleAufbewahrungsorte();
        Task LoescheAufbewahrungsort(Aufbewahrungsort ort);
        Task SpeichereAufbewahrungsort(Aufbewahrungsort ort);
    }
}