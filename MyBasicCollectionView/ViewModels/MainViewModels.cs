using MyBasicCollectionView.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace MyBasicCollectionView.ViewModels
{
    public class MainViewModels
    {
        public ObservableCollection<Person> Peoples { get; set; }
        public ICommand DeletePersonCommand { get; }
        public ICommand AddPersonCommand { get; }
        public MainViewModels()
        {
            Peoples = new ObservableCollection<Person>
            {
                new Person { Id = "1", Name = "John Doe", Company = "Acme Inc.", Job = "Software Engineer" },
                new Person { Id = "2", Name = "Jane Smith", Company = "Globex Corporation", Job = "Project Manager" },
                new Person { Id = "3", Name = "Alice Johnson", Company = "Initech", Job = "UX Designer" },
                new Person { Id = "4", Name = "Bob Brown", Company = "Umbrella Corp.", Job = "Data Analyst" },
                new Person { Id = "5", Name = "Charlie Davis", Company = "Hooli", Job = "DevOps Engineer" },
                new Person { Id = "6", Name = "Eve Wilson", Company = "Stark Industries", Job = "Product Manager" },
                new Person { Id = "7", Name = "Frank Miller", Company = "Wayne Enterprises", Job = "Security Specialist" },
                new Person { Id = "8", Name = "Grace Lee", Company = "Cyberdyne Systems", Job = "AI Researcher" },
                new Person { Id = "9", Name = "Hank Green", Company = "Vandelay Industries", Job = "Sales Manager" },
                new Person { Id = "10", Name = "Ivy Turner", Company = "Soylent Corp.", Job = "Marketing Director" }
            };

            DeletePersonCommand = new Command<string>(DeletePerson);
            AddPersonCommand = new Command(AddPerson);
        }

        private string _job;
        public string Job
        {
            get => _job;
            set
            {
                _job = value;
                OnPropertyChanged();
            }
        }   


        private string _newPersonName;
        public string NewPersonName
        {
            get => _newPersonName;
            set
            {
                _newPersonName = value;
                OnPropertyChanged();
            }
        }

        private string _newPersonCompany;
        public string NewPersonCompany
        {
            get => _newPersonCompany;
            set
            {
                _newPersonCompany = value;
                OnPropertyChanged();
            }
        }

        // Add a new person to the collection
        public void AddPerson()
        {
            if (string.IsNullOrWhiteSpace(NewPersonName) ||
                string.IsNullOrWhiteSpace(NewPersonCompany))
                return;

            Peoples.Add(new Person
            {
                Id = Guid.NewGuid().ToString(),
                Name = NewPersonName,
                Company = NewPersonCompany,
                Job = "New Job"
            });

            NewPersonName = string.Empty;
            NewPersonCompany = string.Empty;
        }

        public void DeletePerson(string id) 
        { 
            var personToDelete = Peoples.FirstOrDefault(p => p.Id == id); 

            if (personToDelete != null) { 
                Peoples.Remove(personToDelete); 
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)

            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));



    }
}
