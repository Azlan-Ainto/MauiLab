using DontLeMeExpire.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DontLeMeExpire.Services
{
    class TestProduktService
    {
        private readonly List<Produkt> _produkte;


        public TestProduktService()
        {
            _produkte = [.. TestDaten.Produkte];
        }

        /// <summary>
        /// gibt alle Produkte zurück, sortiert nach Verfallsdatum(Asynchron)
        /// </summary>
        /// <returns>eine Liste vom Typ Enumerable</returns>
        public Task<IEnumerable<Produkt>> LadeProduktliste()
        {
            return Task.FromResult(_produkte.OrderBy(produkt => produkt.Verfallsdatum).AsEnumerable());
        }

        /// <summary>
        ///  gibt ein spezifisches Produkt zurück.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>gibt ein Objekt vom Produkt zurück</returns>

        public Task<Produkt?> ProduktLaden(string id)
        {
            Produkt produkt = _produkte.SingleOrDefault(p => p.Id == id);

            return Task.FromResult(produkt);

        }


        public Task LoescheAlleProdukte()
        {
            _produkte.Clear();
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Produkt>> FindeProdukteNachLagerort(string aufbewahrungsort)
        {
            // sortierte Produkte
            var produkte = _produkte.OrderBy(p => p.Verfallsdatum);

            // gefilterte Produkte

            var artikel = produkte.Where(p => p.Aufbewahrungsort == aufbewahrungsort);

            return Task.FromResult(artikel.AsEnumerable());

            //return Task.FromResult(_produkte.OrderBy(p => p.Verfallsdatum).Where(p => p.Aufbewahrungsort == aufbewahrungsort).AsEnumerable());

        }

        public Task<IEnumerable<Produkt>> LadeAbgelaufeneProdukte()
        {

            // sortierte Produkte
            var produkte = _produkte.OrderBy(p => p.Verfallsdatum);
            // gefilterte Produkte
            var artikel = _produkte.Where(p => p.Verfallsdatum < DateTime.Today).AsEnumerable();

            return Task.FromResult(artikel);

            // return Task.FromResult(_produkte.OrderBy(p => p.Verfallsdatum).Where(p => p.Verfallsdatum == DateTime.Today).AsEnumerable());
        }


        // Lädt alle Produkte, die heute ablaufen
        public Task<IEnumerable<Produkt>> LadeProdukteHeuteAblaufen()
        {
            // lade  alle Produkte und sortiere nach Produktname
            var produkte = _produkte.OrderBy(p => p.Produktname);

            // filtere alle Produkte, die heute ablaufen
            var artikel = _produkte.Where(p => p.Verfallsdatum == DateTime.Today);

            return Task.FromResult(artikel.AsEnumerable());

        }

        // lädt alle Produkte, die bald ablaufen

        public Task<IEnumerable<Produkt>> LadeProdukteBaldAblaufen(int tage=5)
        {

            var verfallsdatumZukunft = DateTime.Today.AddDays(tage);

            var produkte = _produkte.OrderBy(p => p.Verfallsdatum);

            var artikel = _produkte.Where(p => p.Verfallsdatum >= DateTime.Today && p.Verfallsdatum <= verfallsdatumZukunft);

            return Task.FromResult(artikel.AsEnumerable());
        }


        public Task SpeichereProdukt(Produkt produkt)
        {
            // prüfen, ob das Objekt prdukt erzeugt wurde und nicht null ist
            if (produkt is null) 
                throw new ArgumentNullException(nameof(produkt));

            //Prüfen, ob das Produkt eine Id hat oder noch keine Zuweisung hat
            bool hatLeereId = string.IsNullOrEmpty(produkt.Id) || produkt.Id == Guid.Empty.ToString();

            //Prüfen, ob das Produkt  bereits in der Liste enthalten
            bool produktEnthalten = _produkte.Any(p => p.Id == produkt.Id);

            // Falls das Produkt keine Id hat dann eine neue Id zuweisen und in die Liste hinzufügen
            // Falls das Produkt nicht in der Liste enthalten ist und eine Id hat, dann in die Liste hinzufügen
            // Ansonsten das vorhandene Produkt aktualisieren
            if (hatLeereId || !produktEnthalten)
            {
                if (hatLeereId)
                {
                    produkt.Id = Guid.NewGuid().ToString();
                }
                _produkte.Add(produkt);
            }else
            {
                Produkt produktAktualisieren = _produkte.Single(p => p.Id == produkt.Id);
                // Prdodukt aktualisieren
                produktAktualisieren.Produktname = produkt.Produktname; 
                produktAktualisieren.Verfallsdatum = produkt.Verfallsdatum; 
                produktAktualisieren.Aufbewahrungsort = produkt.Aufbewahrungsort;
                produktAktualisieren.Foto = produkt.Foto;
            }
            return Task.CompletedTask;
        }

        public Task LoescheProdukt(Produkt produkt)
        {
            //  prüfen, ob das produkt existiert
            bool produktEnthalten = _produkte.Any(p => p.Id == produkt.Id);
            
            // prüfen, ob das Produkt eine Id hat
            bool hatId = !string.IsNullOrEmpty(produkt.Id);

            // Falls das Produkt in der Liste enthalten ist und eine Id hat, dann löschen
            if (produktEnthalten && hatId)
            {
                Produkt produktLoeschen = _produkte.Single(p => p.Id == produkt.Id);
                _produkte.Remove(produktLoeschen);
            }

            return Task.CompletedTask;

        }

    }
}
