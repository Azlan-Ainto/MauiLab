using TaskSuite.Models;
using TaskSuite.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskSuite.Models;
using TaskSuite.Services;

namespace TaskSuite.ViewModels
{
    [QueryProperty(nameof(TodoItem), "TodoItem")]
    public partial class DetailViewModel : ObservableObject
    {
        private readonly ToDoService _service;

        [ObservableProperty]
        private ToDoItem todoItem;

        // Listen für die UI (Picker und RadioButtons)
        public List<ToDoStatus> StatusList => Enum.GetValues(typeof(ToDoStatus)).Cast<ToDoStatus>().ToList();
        public List<ToDoCategory> Categories => Enum.GetValues(typeof(ToDoCategory)).Cast<ToDoCategory>().ToList();

        public DetailViewModel(ToDoService service)
        {
            _service = service;
            // Falls wir ein neues Item erstellen, initialisieren wir es hier
            todoItem = new ToDoItem
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(1),
                StartTime = DateTime.Now.TimeOfDay,
                EndTime = DateTime.Now.AddHours(1).TimeOfDay
            };
        }

        [RelayCommand]
        async Task SaveAsync()
        {
            if (string.IsNullOrWhiteSpace(TodoItem.Title)) return;

            await _service.SaveItemAsync(TodoItem);
            await Shell.Current.GoToAsync(".."); // Zurück zur Hauptseite
        }

        [RelayCommand]
        async Task CancelAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}