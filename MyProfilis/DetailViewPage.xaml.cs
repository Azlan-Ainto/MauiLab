
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using MyProfilis.Data;
using MyProfilis.Models;


using MyProfilis.Models;

namespace MyProfilis;

[QueryProperty(nameof(Person), "person")]
public partial class DetailViewPage : ContentPage
{
    private readonly DetailViewModel viewModel;

    public Person Person
    {
        set
        {
            if (BindingContext is DetailViewModel vm)
                vm.Initialize(value);
        }
    }

    public DetailViewPage(DetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = viewModel = vm;
    }
}






