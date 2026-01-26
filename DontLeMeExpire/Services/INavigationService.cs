using System;
using System.Collections.Generic;
using System.Text;

namespace DontLeMeExpire.Services
{
    public interface INavigationService
    {
        Task GoToAsync(string loacation);
        Task GotToAsync(string location, bool animate);
        Task GoToAsync(string location, Dictionary<string, object> parameters);
        Task GoToAsync(string location, bool animate, Dictionary<string, object> parameters);

    }
}
