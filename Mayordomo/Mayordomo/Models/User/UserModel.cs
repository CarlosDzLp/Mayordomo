using System;
using Newtonsoft.Json;

namespace Mayordomo.Models.User
{
    public class UserModel
    {
        [JsonProperty("IdUser")]
        public Guid IdUser { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Photo")]
        public string Photo { get; set; }

        [JsonProperty("Status")]
        public bool Status { get; set; }

        [JsonProperty("UserType")]
        public int UserType { get; set; }

        [JsonProperty("PhotoBytes")]
        public byte[] PhotoBytes { get; set; }
    }
}
