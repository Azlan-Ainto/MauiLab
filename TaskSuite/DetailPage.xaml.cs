using TaskSuite.ViewModels;
namespace TaskSuite;

    public partial class DetailPage : ContentPage
    {
        public DetailPage(DetailViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }
    }
