using System;
using System.Collections.Generic;
using System.Text;

namespace Mayordomo.ViewModels.Authenticate
{
    public class TokenRequest
    {
        public string Token { get; set; }
        public int Expired { get; set; }
        public DateTime Date { get; set; }
    }
}
