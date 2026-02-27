using MyBasicCollectionView.ViewModels;


namespace MyBasicCollectionView
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage(MainViewModels vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }


    }
}
