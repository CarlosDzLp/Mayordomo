using MayordomoApp.Helpers;
using FormsToolkit;
using MayordomoApp.ViewModels.Session;
using Xamarin.Forms;

namespace MayordomoApp.Views.Session
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
            MessagingService.Current.SendMessage<MessageKeys>("StatusBar", new MessageKeys { StatusBarTransparent = true, ColorHex = "#0CB392" });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingService.Current.Unsubscribe("StatusBar");
        }
    }
}
