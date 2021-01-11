using System;
using System.Collections.Generic;
using FormsToolkit;
using Mayordomo.Helpers;
using Mayordomo.ViewModels.Session;
using Xamarin.Forms;

namespace Mayordomo.Views.Session
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //MessagingService.Current.SendMessage<MessageKeys>("StatusBar", new MessageKeys { StatusBarTransparent = true, ColorHex = "#06214B" });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //MessagingService.Current.Unsubscribe("StatusBar");
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            App.NavigationAsync.Navigation.RemovePage(this);
        }
    }
}
