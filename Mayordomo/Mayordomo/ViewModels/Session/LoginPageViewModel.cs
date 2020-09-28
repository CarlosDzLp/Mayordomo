using System;
using System.Windows.Input;
using Mayordomo.Enums;
using Mayordomo.ViewModels.Base;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Mayordomo.ViewModels.Session
{
    public class LoginPageViewModel : BindableBase
    {
        #region Constructor
        public LoginPageViewModel()
        {
            LogInCommand = new Command(LogInCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand LogInCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async void LogInCommandExecuted()
        {
            try
            {
                App.Current.MainPage = App.Navigation( new Views.Principal.MasterPage());
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
