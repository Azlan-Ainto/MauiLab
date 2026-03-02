using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using MyProfilis.Data;
using MyProfilis.Models;
using System.Collections.ObjectModel;

namespace MyProfilis.ViewModel;



public partial class SearchViewModel : ObservableObject
{
    private readonly AppDbContext _context;

    public ObservableCollection<Person> Personen { get; } = new();

    [ObservableProperty]
    private string? searchText;

    [ObservableProperty]
    private Person? selectedPerson;

    public bool IsPersonSelected => SelectedPerson != null;

    public SearchViewModel(AppDbContext context)
    {
        _context = context;
        LoadAll();
    }

    private void LoadAll()
    {
        Personen.Clear();
        var list = _context.Personen.AsNoTracking().ToList();
        foreach (var p in list)
            Personen.Add(p);
    }

    partial void OnSelectedPersonChanged(Person? value)
    {
        OnPropertyChanged(nameof(IsPersonSelected));
    }

    [RelayCommand]
    private void Search()
    {
        Personen.Clear();

        var result = _context.Personen
            .AsNoTracking()
            .Where(p =>
                p.Vorname!.Contains(SearchText!) ||
                p.Nachname!.Contains(SearchText!)).ToList();

        foreach (var p in result)
            Personen.Add(p);
    }

    public void Reload()
    {
        Personen.Clear();

        var list = _context.Personen.AsNoTracking().ToList();

        foreach (var p in list)
            Personen.Add(p);
    }
}
