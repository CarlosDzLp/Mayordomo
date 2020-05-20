using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MayordomoApp.ViewModels.Base;
using MayordomoApp.Controls;

namespace MayordomoApp.ViewModels.Session
{
    public class LoginPageViewModel : BindableBase
    {
        #region Constructor
        public LoginPageViewModel()
        {
            RegisterCommand = new Command(RegisterCommandExecuted);
            SigInCommand = new Command(SigInCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand RegisterCommand { get; set; }
        public ICommand SigInCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void RegisterCommandExecuted()
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Session.RegisterPage());
        }
        private void SigInCommandExecuted()
        {
            App.Current.MainPage = new NavigationViewPage(new Views.Principal.MasterPage());
        }
        #endregion
    }
}
