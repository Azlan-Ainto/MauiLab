namespace DontLeMeExpire.Views;
using DontLeMeExpire.ViewModels;


public partial class ProduktPage : ContentPage
{

	private ProduktViewModel _viewModel;




    public ProduktPage(ProduktViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

	protected async override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		await _viewModel.Initialisierung();
		base.OnNavigatedTo(args);
    }
}