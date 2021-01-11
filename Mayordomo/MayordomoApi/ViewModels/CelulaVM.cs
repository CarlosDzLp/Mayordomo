using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MayordomoApi.ViewModels
{
    public class CelulaVM
    {
        public Guid IdCelula { get; set; }
        public string Nombre { get; set; }
        public string Address { get; set; }
        public string NombrePersona { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool? Status { get; set; }
    }
}