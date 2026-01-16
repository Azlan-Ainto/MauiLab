using DontLeMeExpire.ViewModels;
using System.Threading.Tasks;

namespace DontLeMeExpire
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;
     


        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }


   

        
    }
}
