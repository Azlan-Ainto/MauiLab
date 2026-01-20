using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace DontLeMeExpire.ViewModels
{
    public abstract class ValidationViewModelBase : ViewModelBase
    {
        //Dictionary enthält die Validierungsfehler
        private readonly Dictionary<string, List<ValidationResult>> _errors = [];
        //
        private readonly ValidationContext _validationContext;



        protected ValidationViewModelBase()
        {
            _validationContext = new ValidationContext(this);
        }

        // gibt alle Fehler zurück
        public IEnumerable<string> ErrorMessages => _errors.Values.SelectMany(errors => errors.Select(e => e.ErrorMessage));

        // gibt zurück ob Validierungsfehler vorhanden sind
        public bool HasErrors => _errors.Any();

        // Liefert ein Dictionary mit den Validierungsfehlern zurück
        public Dictionary<string, IEnumerable<string>> PropertyErrorMessages
        {
            get
            {
                return _errors.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Select(e => e.ErrorMessage).AsEnumerable()
                );

            }
        }


        // Fügt der Liste von Fehlern alle Fehler einer Eigenschaft hinzu
        protected virtual void AddErrors(string propertyName, List<ValidationResult> validationResults)
        {
            // Falls es die gleichen Fehler bereits in der Liste gibt, springen wir direkt aus dem Code heraus
            if (_errors.ContainsKey(propertyName) && _errors[propertyName].SequenceEqual(validationResults))
            {
                return;
            }
            _errors[propertyName] = validationResults;
            // UI über die Änderung informieren
            OnPropertyChanged(nameof(HasErrors));
            OnPropertyChanged(nameof(ErrorMessages));
            OnPropertyChanged(nameof(PropertyErrorMessages));


        }

        // Validiert alle Eigenschaften der ViewModel-Klasse
        public virtual bool ValidateAllProperties()
        {
            var isValid = true;
            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(this);
                isValid = isValid && ValidateProperty(value, property.Name);
            }
            return isValid;

        }


        // Validiert eine einzelne Eigenschaft der ViewModel-Klasse
        public virtual bool ValidateProperty(object? value, [CallerMemberName] string propertyName = null!)
        {


            _validationContext.MemberName = propertyName;
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateProperty(value, _validationContext, validationResults);

            if (isValid)
            {
                RemoveErrors(propertyName);
            }
            else
            {
                AddErrors(propertyName, validationResults);

            }
            return isValid;
        }

        // Entfernt alle Fehler einer Eigenschaft aus der Liste
        protected virtual void RemoveErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName) && _errors[propertyName].Count > 0)
            {
                _errors.Remove(propertyName);
                // UI über die Änderung informieren
                OnPropertyChanged(nameof(HasErrors));
                OnPropertyChanged(nameof(ErrorMessages));
                OnPropertyChanged(nameof(PropertyErrorMessages));


            }
        }

        // validiert das ganze ViewModel
        public bool Validate()
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(this);
            bool isValid = Validator.TryValidateObject(this, context, validationResults, true);

            _errors.Clear();
            if (!isValid)
            {
                foreach(var validationResult in validationResults)
                {
                    foreach(var memberName in validationResult.MemberNames)
                    {
                        AddErrors(memberName, [validationResult]);
                    }
                }
            }
            // UI über die Änderung informieren
            OnPropertyChanged(nameof(HasErrors));
            OnPropertyChanged(nameof(ErrorMessages));
            OnPropertyChanged(nameof(PropertyErrorMessages));
            return isValid;
        }
    }
}
