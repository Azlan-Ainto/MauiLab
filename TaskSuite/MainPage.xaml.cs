using TaskSuite.Models;
using TaskSuite.ViewModels;
using Microsoft.Maui.Controls;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _vm;

    public MainPage(MainViewModel vm)
    {
        //InitializeComponent();
        InitializeComponent();
       this.BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Standardmäßig nach Tag laden
        await _vm.LoadItemsAsync(ToDoGroup.SelectedItem?.ToString() ?? "Tag");
    }

    private async void OnGroupChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        await _vm.LoadItemsAsync(picker.SelectedItem.ToString());
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        // Navigation zur Detailseite (für neuen Eintrag)
        await Shell.Current.GoToAsync("DetailPage");
    }

    private async void OnEditItemTapped(object sender, EventArgs e)
    {
        var border = (Border)sender;
        var item = (ToDoItem)((TapGestureRecognizer)border.GestureRecognizers[0]).CommandParameter;

        // Navigation zur Detailseite mit dem gewählten Objekt
        var navigationParameter = new Dictionary<string, object> { { "TodoItem", item } };
        await Shell.Current.GoToAsync("DetailPage", navigationParameter);
    }



}