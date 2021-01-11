using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MayordomoApi.ViewModels
{
    public class UserVM
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public bool? Status { get; set; }
        public int? UserType { get; set; }
        public byte[] PhotoBytes { get; set; }
    }
}