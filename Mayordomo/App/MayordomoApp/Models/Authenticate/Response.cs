using System;
using Newtonsoft.Json;

namespace MayordomoApp.Models.Authenticate
{
    public class Response<T>
    {
        [JsonProperty("Result")]
        public T Result { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}
