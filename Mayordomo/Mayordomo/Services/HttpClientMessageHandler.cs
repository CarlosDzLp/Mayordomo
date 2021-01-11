using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mayordomo.DataBases;
using Mayordomo.Helpers;
using Mayordomo.Models.Authenticate;
using Mayordomo.Models.User;
using Newtonsoft.Json;

namespace Mayordomo.Services
{
    public class HttpClientMessageHandler : DelegatingHandler
    {
        public HttpClientMessageHandler()
        {
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await base.SendAsync(request, cancellationToken);
                if (response.StatusCode == HttpStatusCode.Unauthorized && request.Headers.Where(c => c.Key == "Authorization").Select(c => c.Value).Any(c => c.Any(p => p.StartsWith("Bearer"))))
                {
                    var us = DbContext.Instance.GetUser();
                    var user = new UserModel()
                    {
                        Email = us.Email,
                        Password = us.Password
                    };
                    using (var refreshResponse = await SendAsync(new HttpRequestMessage(HttpMethod.Post, Settings.URL + "api/authenticate/aoth")
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")
                    },
                    cancellationToken))
                    {
                        var rawResponse = await refreshResponse.Content.ReadAsStringAsync();
                        var x = JsonConvert.DeserializeObject<TokenResponse>(rawResponse);
                        request.Headers.Remove("Authorization");
                        request.Headers.Add("Authorization", "Bearer " + x.Token);
                        //retry actual request with new tokens
                        response = await SendAsync(request, cancellationToken);
                        DbContext.Instance.InsertToken(x);
                    }
                }
                return response;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
