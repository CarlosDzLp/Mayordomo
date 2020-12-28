using System;
using Newtonsoft.Json;

namespace Mayordomo.Models.WSResponse
{
    public class Response<T>
    {
        [JsonProperty("Result")]
        public T Result { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }
    }
}
