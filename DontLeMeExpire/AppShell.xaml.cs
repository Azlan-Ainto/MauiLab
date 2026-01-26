namespace DontLeMeExpire
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.ProduktPage), typeof(Views.ProduktPage));
        }
    }
}
