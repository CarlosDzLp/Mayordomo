using System;
using System.Collections.Generic;
using Mayordomo.ViewModels.Presentation;
using Xamarin.Forms;

namespace Mayordomo.Views.Presentation
{
    public partial class PresentationPage : ContentPage
    {
        public PresentationPage()
        {
            InitializeComponent();
            this.BindingContext = new PresentationPageViewModel();
        }
    }
}
