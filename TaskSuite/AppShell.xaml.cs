namespace TaskSuite
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Route für die Detailseite registrieren
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        }
    }
}
