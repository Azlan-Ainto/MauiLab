using MyProfilis.ViewModel;

namespace MyProfilis
{
    public partial class MainPage : ContentPage
    {
        private PersonViewModel _viewModel;
   

        public MainPage(PersonViewModel  vm)
        {
            InitializeComponent();
      
            BindingContext = _viewModel = vm;
        }

       
    }
}
