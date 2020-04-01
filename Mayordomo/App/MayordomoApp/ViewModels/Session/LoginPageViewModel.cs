using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MayordomoApp.ViewModels.Base;

namespace MayordomoApp.ViewModels.Session
{
    public class LoginPageViewModel : BindableBase
    {
        #region Constructor
        private bool _isVisibleLogIn = true;
        public bool IsVisibleLogIn
        {
            get { return _isVisibleLogIn; }
            set { SetProperty(ref _isVisibleLogIn, value); }
        }
        private bool _isVisibleRegister;
        public bool IsVisibleRegister
        {
            get { return _isVisibleRegister; }
            set { SetProperty(ref _isVisibleRegister, value); }
        }
        private bool _isLogIn = true;
        public bool IsLogIn
        {
            get { return _isLogIn; }
            set { SetProperty(ref _isLogIn, value); }
        }
        private bool _isRegister;
        public bool IsRegister
        {
            get { return _isRegister; }
            set { SetProperty(ref _isRegister, value); }
        }
        #endregion

        #region Constructor
        public LoginPageViewModel()
        {
            TapRegisterCommand = new Command(TapRegisterCommandExecuted);
            TapLogInCommand = new Command(TapLogInCommandExecuted);
            LogInCommand = new Command(LogInCommandExecuted);
            RegisterCommand = new Command(RegisterCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand TapLogInCommand { get; set; }
        public ICommand TapRegisterCommand { get; set; }
        public ICommand LogInCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void TapRegisterCommandExecuted()
        {
            IsVisibleLogIn = false;
            IsVisibleRegister = true;
            IsLogIn = false;
            IsRegister = true;
        }

        private void TapLogInCommandExecuted()
        {
            IsVisibleLogIn = true;
            IsVisibleRegister = false;
            IsLogIn = true;
            IsRegister = false;
        }

        private void LogInCommandExecuted()
        {
            //loginCommand
        }

        private void RegisterCommandExecuted()
        {
            //registercommand
        }
        #endregion
    }
}
