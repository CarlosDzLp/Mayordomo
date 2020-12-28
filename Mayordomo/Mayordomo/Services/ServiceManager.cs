using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Mayordomo.Helpers;
using Mayordomo.Models.User;
using Mayordomo.Models.WSResponse;
using Newtonsoft.Json;
using Refit;

namespace Mayordomo.Services
{
    public class ServiceManager : IServiceManager
    {
        protected HttpClient _httpClient;
        protected RefitSettings _refitSettings;
        protected JsonSerializerSettings _jsonSerializerSettings;
        protected ConnectionApi connectionApi;

        public ServiceManager()
        {
            //Implementar Handler mas adelante para revizar trafico de respuestas new HttpLoggingHandler()
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Settings.URL),
                Timeout = TimeSpan.FromMinutes(Settings.TIME_OUT)
            };
            _refitSettings = new RefitSettings();
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                Error = new EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>(ErrorSerializer),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None,            
            };
            _refitSettings.ContentSerializer = new NewtonsoftJsonContentSerializer(_jsonSerializerSettings);
            connectionApi = Refit.RestService.For<ConnectionApi>(_httpClient, _refitSettings);
        }

        public void ErrorSerializer(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e)
        {
            e.ErrorContext.Handled = true;
        }

        public async Task<Response<bool>> InsertUser(UserModel user)
        {
            try
            {
                var result = await connectionApi.InsertUser(user);
                if (result.StatusCode == HttpStatusCode.OK)
                    return result.Content;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Response<bool>> ValidateEmail(string email)
        {
            try
            {
                var result = await connectionApi.ValidateEmail(email);
                if (result.StatusCode == HttpStatusCode.OK)
                    return result.Content;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
