using System;
using System.Collections.Generic;
using Mayordomo.ViewModels.Session;
using Xamarin.Forms;

namespace Mayordomo.Views.Session
{
    public partial class EmailValidatePage : ContentPage
    {
        public EmailValidatePage()
        {
            InitializeComponent();
            this.BindingContext = new EmailValidatePageViewModel();
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            App.NavigationAsync.Navigation.RemovePage(this);
        }
    }
}
