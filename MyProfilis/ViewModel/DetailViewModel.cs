using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using MyProfilis.Data;
using MyProfilis.Models;

public partial class DetailViewModel : ObservableObject
{
    private readonly AppDbContext _context;

    private Person _person;

    public Person Person
    {
        get => _person;
        set
        {
            _person = value;
            OnPropertyChanged();
        }
    }

    public DetailViewModel(AppDbContext context)
    {
        _context = context;
    }

    public void Initialize(Person person)
    {
        Person = person;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        var existing = await _context.Personen.FirstOrDefaultAsync(p => p.ID == Person.ID);

        if (existing != null)
        {
            existing.Vorname = Person.Vorname;
            existing.Nachname = Person.Nachname;
            existing.EMail = Person.EMail;
            existing.Telefon = Person.Telefon;
            existing.Stadt = Person.Stadt;
            existing.Land = Person.Land;
            existing.Postleitzahl = Person.Postleitzahl;
            existing.Straße = Person.Straße;
            existing.Hausnummer = Person.Hausnummer;
            existing.Geburtsdatum = Person.Geburtsdatum;

            await _context.SaveChangesAsync();
        }

        await Shell.Current.DisplayAlertAsync("Erfolg", "Datensatz wurde aktualisiert.",  "OK");
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        bool confirm = await Shell.Current.DisplayAlertAsync("Bestätigung", "Datensatz wirklich löschen?", "Ja","Nein");

        if (!confirm)
            return;

        var existing = await _context.Personen.FirstOrDefaultAsync(p => p.ID == Person.ID);

        if (existing != null)
        {
            _context.Personen.Remove(existing);
            await _context.SaveChangesAsync();
        }

        await Shell.Current.GoToAsync("..");
    }
}