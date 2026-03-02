
using MyProfilis.Models;
using MyProfilis.ViewModel;

namespace MyProfilis
{

	public partial class SearchPage : ContentPage
	{
		
        private readonly SearchViewModel viewModel;
        public SearchPage(SearchViewModel vm)
		{
			InitializeComponent();

			BindingContext = viewModel = vm;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.Reload();
        }



        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Person person)
            {
                var navigationParameter = new Dictionary<string, object>
            {
                { "person", person }
            };

                await Shell.Current.GoToAsync(nameof(DetailViewPage), navigationParameter);
            }
        }
    }
}