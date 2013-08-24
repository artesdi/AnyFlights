using System;
using System.Threading.Tasks;

namespace AnyFlights.Networking
{
    public interface IWebService
    {
        Task<T> Get<T>(string url, TimeSpan timeout, bool usingNetworkStackCache = false) where T : new();
    }
}