using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TaskSuite.Models;
using TaskSuite.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TaskSuite.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly ToDoService _service;

        [ObservableProperty]
        private ObservableCollection<ToDoGroup> groupedItems = new();

        [ObservableProperty]
        private bool isRefreshing;

        public MainViewModel(ToDoService service)
        {
            _service = service;
        }

        // Diese Methode gruppiert die Daten je nach Wunsch
        [RelayCommand]
        public async Task LoadItemsAsync(string groupByType = "Tag")
        {
            IsRefreshing = true;
            var allItems = await _service.GetItemsAsync();

            IEnumerable<IGrouping<string, ToDoItem>> groups;

            // Gruppierungslogik basierend auf deinem Wunsch
            groups = groupByType switch
            {
                "Jahr" => allItems.OrderBy(x => x.StartDate).GroupBy(x => x.StartDate.Year.ToString()),
                "Monat" => allItems.OrderBy(x => x.StartDate).GroupBy(x => x.StartDate.ToString("MMMM yyyy")),
                "Woche" => allItems.OrderBy(x => x.StartDate).GroupBy(x => "KW " + System.Globalization.ISOWeek.GetWeekOfYear(x.StartDate)),
                _ => allItems.OrderBy(x => x.StartDate).GroupBy(x => x.StartDate.ToShortDateString()), // Standard: Tag
            };

            GroupedItems.Clear();
            foreach (var g in groups)
            {
                GroupedItems.Add(new ToDoGroup(g.Key, g.ToList()));
            }
            IsRefreshing = false;
        }

        [RelayCommand]
        public async Task DeleteItemAsync(ToDoItem item)
        {
            if (item == null) return;
            await _service.DeleteItemAsync(item);
            await LoadItemsAsync(); // Liste neu laden
        }
    }
}
