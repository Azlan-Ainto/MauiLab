using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyProfilis.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyProfilis.Models;


namespace MyProfilis.ViewModel
{
    public partial class PersonViewModel : ObservableObject
    {
        private readonly AppDbContext _context;

        public ObservableCollection<Person> Personen { get; } = new();

        [ObservableProperty]
        private string? vorname;
        [ObservableProperty]
        private string? nachname;
        [ObservableProperty]
        private DateTime geburtsdatum = DateTime.Today;
        [ObservableProperty]
        private string? eMail;
        [ObservableProperty]
        private string? telefon;
        [ObservableProperty]
        private string? land;
        [ObservableProperty]
        private string? stadt;
        [ObservableProperty]
        private string? postleitzahl;
        [ObservableProperty]
        private string? straße;
        [ObservableProperty]
        private string? hausnummer;

        public PersonViewModel(AppDbContext context)
        {
            _context = context;
            LoadData();
        }

        private void LoadData()
        {
            Personen.Clear();
            var persons = _context.Personen.AsNoTracking().ToList();
            foreach (var p in persons)
                Personen.Add(p);
        }

        [RelayCommand]
        private async Task SaveAsync()
        {
            var validationError = Validate();
            var page = Application.Current?.Windows.FirstOrDefault()?.Page;

            if (validationError != null)
            {
               

                if (page != null)
                    await page.DisplayAlertAsync("Validierungsfehler", validationError,"OK");
                return;
            }
            var person = new Person
            {
                Vorname = Vorname,
                Nachname = Nachname,
                Geburtsdatum = Geburtsdatum,
                EMail = EMail,
                Telefon = Telefon,
                Land = Land,
                Stadt = Stadt,
                Postleitzahl = Postleitzahl,
                Straße = Straße,
                Hausnummer = Hausnummer
            };

            _context.Personen.Add(person);
            await _context.SaveChangesAsync();

            //LoadData();
            ClearForm();

                await Application.Current.Windows.FirstOrDefault().Page.DisplayAlertAsync("Erfolg", "Der Datensatz wurde erfolgreich gespeichert.", "OK");
           
        }

        private void ClearForm()
        {
            Vorname = string.Empty;
            Nachname = string.Empty;
            EMail = string.Empty;
            Telefon = string.Empty;
            Land = string.Empty;
            Stadt = string.Empty;
            Postleitzahl = string.Empty;
            Straße = string.Empty;
            Hausnummer = string.Empty;
            Geburtsdatum = DateTime.Today;
        }

        private string? Validate()
        {
            if (string.IsNullOrWhiteSpace(Vorname))
                return "Vorname ist erforderlich.";

            if (string.IsNullOrWhiteSpace(Nachname))
                return "Nachname ist erforderlich.";

            if (string.IsNullOrWhiteSpace(EMail) || !EMail.Contains("@"))
                return "Bitte eine gültige E-Mail-Adresse eingeben.";

            if (Geburtsdatum > DateTime.Today)
                return "Geburtsdatum ist ungültig.";

            if (string.IsNullOrWhiteSpace(Postleitzahl))
                return "Postleitzahl ist erforderlich.";

            return null; // Keine Fehler
        }
    }
}
