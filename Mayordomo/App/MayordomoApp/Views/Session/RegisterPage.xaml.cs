using System;
using System.Collections.Generic;
using FormsToolkit;
using MayordomoApp.Helpers;
using MayordomoApp.ViewModels.Session;
using Xamarin.Forms;

namespace MayordomoApp.Views.Session
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = new RegisterPageViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingService.Current.SendMessage<MessageKeys>("StatusBar", new MessageKeys { StatusBarTransparent = false, ColorHex = "#1C2E29" });
            //
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingService.Current.Unsubscribe("StatusBar");
        }
    }
}
