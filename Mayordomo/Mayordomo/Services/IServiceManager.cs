using System;
using System.Threading.Tasks;
using Mayordomo.Models.Authenticate;
using Mayordomo.Models.User;
using Mayordomo.Models.WSResponse;

namespace Mayordomo.Services
{
    public interface IServiceManager
    {
        Task<T> Get<T>(string url, string token = null);
        Task<T> Post<T>(string deserialice, string url, string token = null);
        Task<T> Put<T>(string deserialice, string url, string token = null);
        Task<T> Delete<T>(string url, string token = null);
    }
}
