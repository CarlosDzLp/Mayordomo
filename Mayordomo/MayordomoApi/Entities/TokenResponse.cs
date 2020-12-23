using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MayordomoApi.Entities
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime Expired { get; set; }
    }
}