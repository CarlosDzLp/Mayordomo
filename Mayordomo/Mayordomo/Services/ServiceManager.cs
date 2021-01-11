using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Mayordomo.Helpers;

namespace Mayordomo.Services
{
    public class ServiceManager : IServiceManager
    {
        public async Task<T> Delete<T>(string url, string token = null)
        {
            try
            {
                T deserializer = default(T);
                HttpClient client = new HttpClient(new HttpClientMessageHandler());
                var urltype = Settings.URL + url;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.DeleteAsync(urltype);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> Get<T>(string url, string token = null)
        {
            try
            {
                T deserializer = default(T);
                HttpClient client = new HttpClient(new HttpClientMessageHandler());
                var urlType = Settings.URL + url;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync(urlType);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> Post<T>(string deserialice, string url, string token = null)
        {
            try
            {
                T deserializer = default(T);
                HttpClient client = new HttpClient(new HttpClientMessageHandler());
                client.BaseAddress = new Uri(Settings.URL);
                HttpContent content = new StringContent(deserialice, Encoding.UTF8, "application/json");
                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.PostAsync(url, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> Put<T>(string deserialice, string url, string token = null)
        {
            try
            {
                T deserializer = default(T);
                HttpClient client = new HttpClient(new HttpClientMessageHandler());
                client.BaseAddress = new Uri(Settings.URL);
                HttpContent content = new StringContent(deserialice, Encoding.UTF8, "application/json");               
                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.PutAsync(url, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
