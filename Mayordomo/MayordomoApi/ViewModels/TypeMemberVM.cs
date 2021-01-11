using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MayordomoApi.ViewModels
{
    public class TypeMemberVM
    {
        public System.Guid IdMember { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
    }
}