using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsToolkit;
using MayordomoApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MayordomoApp.Views.Principal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : TabbedPage
    {
        public MasterPage()
        {
            InitializeComponent();
            Children.Add(new Views.Principal.UserEnabledPage());
            Children.Add(new Views.Principal.VideoCallPage());
            Children.Add(new Views.Principal.AccountPage());
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
