using System;
using Newtonsoft.Json;
using SQLite;

namespace Mayordomo.Models.Authenticate
{
    public class TokenResponse
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [JsonProperty("Token")]
        public string Token { get; set; }

        [JsonProperty("Expired")]
        public DateTime Expired { get; set; }

        [JsonIgnore]
        public int UserType { get; set; }
    }
}
