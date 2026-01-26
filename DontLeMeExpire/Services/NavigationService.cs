using System;
using System.Collections.Generic;
using System.Text;

namespace DontLeMeExpire.Services
{
    public class NavigationService : INavigationService
    {


        public async Task GoToAsync(string loacation)
        {
           await Shell.Current.GoToAsync(loacation);
        }

        public async Task GotToAsync(string location, bool animate)
        {
            await Shell.Current.GoToAsync(location, animate);
        }

        public async Task GoToAsync(string location, bool animate, Dictionary<string, object> parameters)
        {
            await Shell.Current.GoToAsync(location, animate, parameters);
        }


        public async Task GoToAsync(string location, Dictionary<string, object> parameters)
        {
            await Shell.Current.GoToAsync(location,parameters);
        }


    }
}
