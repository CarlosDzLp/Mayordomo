using System;
using Mayordomo.ViewModels.Base;
using Xamarin.Forms;

namespace Mayordomo.Models.Admin
{
    public class MenuAdmin : BindableNotify
    {
        public string FontFamily { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
        public Color BackgroundColor { get; set; }
    }
}
