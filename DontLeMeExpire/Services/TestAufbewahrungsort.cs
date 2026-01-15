using DontLeMeExpire.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DontLeMeExpire.Services
{
    public class TestAufbewahrungsort
    {
        private readonly TestProduktService _produktService;
        private readonly List<Aufbewahrungsort> _aufbewahrungsorte;


        public TestAufbewahrungsort()
        {
            _produktService = new TestProduktService();
            _aufbewahrungsorte = [.. TestDaten.Orte];

        }

        public Task<IEnumerable<Aufbewahrungsort>> LadeAufbewahrungsorte()
        {
            var orte = _aufbewahrungsorte.OrderBy(o => o.Lagername).ToList();

            return Task.FromResult(orte.AsEnumerable());
        }

        public Task<Aufbewahrungsort?> LadeAufbewahrungsortNachId(string id)
        {
            var ort = _aufbewahrungsorte.SingleOrDefault(ort => ort.AufbewahrungsortId == id);
            return Task.FromResult(ort);
        }

        public Task SpeichereAufbewahrungsort(Aufbewahrungsort ort)
        {
            // wenn das parameter ort nicht existiert, eine Exception werfen
            if (ort == null)
                throw new ArgumentNullException(nameof(ort));

            // prüfen, ob die Id von dem Objekt ort leer oder null ist(noch keine Zuweisung erfolgt ist)
            var hatBereitsId = string.IsNullOrEmpty(ort.AufbewahrungsortId) || ort.AufbewahrungsortId == Guid.Empty.ToString();
            // prüfen, ob der Ort bereits in der Liste existiert
            var istBereitsVorhanden = _aufbewahrungsorte.Any(o => o.AufbewahrungsortId == ort.AufbewahrungsortId);

            // wenn der Ort keine Id hat oder der Ort noch in der List nicht vorhanden ist,
            // dann eine neue Id zuweisen und den Ort zur Liste hinzufügen
            if (hatBereitsId || !istBereitsVorhanden)
            {
                // es kann sein, dass der Ort keine Id hat,
                // aber bereits in der Liste vorhanden ist
                if (hatBereitsId)
                {
                    ort.AufbewahrungsortId = Guid.NewGuid().ToString();
                }
                _aufbewahrungsorte.Add(ort);

            }
            else
            {
                // Ort ist bereits in der Liste vorhanden, also aktualisieren
                var vorhandenerOrt = _aufbewahrungsorte.Single(o => o.AufbewahrungsortId == ort.AufbewahrungsortId);
                vorhandenerOrt.Lagername = ort.Lagername;
                vorhandenerOrt.Icon = ort.Icon;
            }

            return Task.CompletedTask;
        }

        public Task LoescheAufbewahrungsort(Aufbewahrungsort ort)
        {
            // prüfen, ob das parameter ort null ist
            if (ort == null)
                throw new ArgumentNullException(nameof(ort));

            // prüfen, ob die Id von dem Objekt ort leer oder null ist

            bool IstleerOderNull = string.IsNullOrEmpty(ort.AufbewahrungsortId);

            // prüfen, ob der Ort in der Liste bereits vorhanden ist
            Aufbewahrungsort vorhandenerOrt = _aufbewahrungsorte.SingleOrDefault(o => o.AufbewahrungsortId == ort.AufbewahrungsortId);

            // wenn die Id leer oder null ist oder 
            // der Ort nicht in der Liste vorhanden ist, 

            if(!IstleerOderNull && vorhandenerOrt )


            return Task.CompletedTask;

        }
    }
}
