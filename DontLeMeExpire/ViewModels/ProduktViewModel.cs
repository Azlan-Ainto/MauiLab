using DontLeMeExpire.Models;
using DontLeMeExpire.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DontLeMeExpire.ViewModels
{
    public class ProduktViewModel : ValidationViewModelBase
    {
        private string _name = string.Empty;
        private DateTime _verfallsdatum;
        private Aufbewahrungsort? _aufbewahrungsort = null;
        private decimal _menge;
        private string _bild = string.Empty;
        private readonly ILagerService _lagerService;
        private readonly IProduktService _produktService;

        public Command SpeichereCommand { get; set; }
        public ObservableCollection<Aufbewahrungsort> Aufbewahrungsorte { get; set; } = [];


        public ProduktViewModel(ILagerService lagerService, IProduktService produktService)
        {
            // SpeichereCommand = new Command(async () => await Speichere(), KannSpeichern);

            SpeichereCommand = new Command(async () => await Speichere());

            _lagerService = lagerService;

            _produktService = produktService;            
        }

        [Required]
        [Length(1,150)]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public DateTime Verfallsdatum
        {
            get => _verfallsdatum;
            set => SetProperty(ref _verfallsdatum, value);
        }

        public Aufbewahrungsort? Aufbewahrungsort
        {
            get => _aufbewahrungsort;
            set => SetProperty(ref _aufbewahrungsort, value);
        }

        [Required]
        [Length(1, 10000)]
        public decimal Menge
        {
            get => _menge;
            set => SetProperty(ref _menge, value);
        }
        public string Bild
        {
            get => _bild;
            set => _bild = value;
        }

        public async Task Initialisierung()
        {
            var orte = await _lagerService.LadeAufbewahrungsorte();

            Aufbewahrungsorte.Clear();

            foreach (var ort in orte)
            {
                Aufbewahrungsorte.Add(ort);
            }
            Aufbewahrungsort = Aufbewahrungsorte.Count > 0 ? Aufbewahrungsorte[0] : null;
            Verfallsdatum = DateTime.Now;

        }

        private bool KannSpeichern()
        {
            return Validate();
        }

        private async Task Speichere()
        {
            if(!Validate())
                return;
            

            var produkt = new Produkt
            {
                Id = Guid.NewGuid().ToString(),
                Produktname = this.Name,
                Verfallsdatum = this.Verfallsdatum,
                Aufbewahrungsort = this.Aufbewahrungsort?.Lagername,
                Menge = this.Menge,
                Foto = this.Bild
            };

            await _produktService.SpeichereProdukt(produkt);

            Name = string.Empty;
            Menge = 0;
            Verfallsdatum = DateTime.Now;
            if (Aufbewahrungsorte.Count > 0)
                Aufbewahrungsort = Aufbewahrungsorte.First();
            else
                Aufbewahrungsort = null;
        }
    }
}
