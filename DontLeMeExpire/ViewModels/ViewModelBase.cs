using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DontLeMeExpire.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {




        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    

        protected bool SetProperty<T>(ref T field, T value,[CallerMemberName] string propertyName="")
        {
                if (EqualityComparer<T>.Default.Equals(field, value))
                    return false;

                field = value;

                OnPropertyChanged(propertyName);

                return true;



        }

        protected bool SetProperty<T>(ref T field, T value, Action onChanged, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            onChanged?.Invoke();

            return true;
        }






    } 
}
