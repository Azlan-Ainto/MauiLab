using System.Collections.ObjectModel;
using DatakopplungListen.models;

namespace DatakopplungListen
{
    public partial class MainPage : ContentPage
    {

          // Kunde = customer
          // Kunden = customers

        public ObservableCollection<Kunde> Kunden { get; set; } = new ObservableCollection<Kunde>
        {

            new Kunde { Id = "1", Name = "Alice", Company = "TechCorp", Job = "Software Engineer" },
            new Kunde { Id = "2", Name = "Bob", Company = "InnovateX", Job = "Product Manager" },
            new Kunde { Id = "3", Name = "Charlie", Company = "DataSolutions", Job = "Data Scientist" }
        };

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

        }

        
    }
}
