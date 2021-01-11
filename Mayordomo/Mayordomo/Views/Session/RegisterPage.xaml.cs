using System;
using System.Collections.Generic;
using FormsToolkit;
using Mayordomo.Helpers;
using Mayordomo.ViewModels.Session;
using Xamarin.Forms;

namespace Mayordomo.Views.Session
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage(string Email)
        {
            InitializeComponent();
            this.BindingContext = new RegisterPageViewModel(Email);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //MessagingService.Current.SendMessage<MessageKeys>("StatusBar", new MessageKeys { StatusBarTransparent = false, ColorHex = "#1C2E29" });
            //
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //MessagingService.Current.Unsubscribe("StatusBar");
        }

        void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
            App.NavigationAsync.Navigation.RemovePage(this);
        }
    }
}
