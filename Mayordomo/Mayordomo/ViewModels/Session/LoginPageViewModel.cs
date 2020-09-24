using System;
using System.Threading.Tasks;
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
            SigInCommand = new Command(SigInCommandExecuted);
            LogInCommand = new Command(LogInCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand SigInCommand { get; set; }
        public ICommand LogInCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void SigInCommandExecuted()
        {
            //App.NavigationAsync.Navigation.InsertPageBefore
            //App.Current.MainPage = new NavigationPage(new Views.Principal.MasterPage());
        }


        private async void LogInCommandExecuted()
        {
            ////creas la instancia del popup
            //var popup = new Views.Popups.LoadingPopup("Cargando...");

            ////muestras el popup
            //await PopupNavigation.Instance.PushAsync(popup, true);

            ////aqui va la logica de la api
            //await Task.Delay(TimeSpan.FromSeconds(5));
            ////aqui va la logica de la api

            ////cierras el popup
            //await PopupNavigation.Instance.PopAllAsync(true);



            var popupdialog = new Views.Popups.PopupDialog("es un mensage de muestra", PopupDialogsEnum.Success);

            //popupdialog.PopupResponse += Popupdialog_PopupResponse;
            ////muestras el popup
            await PopupNavigation.Instance.PushAsync(popupdialog, true);

        }

        private void Popupdialog_PopupResponse(object sender, PopupState e)
        {
            if (e == PopupState.Cancel)
            {
                Console.WriteLine("CANCEL");
            }
            else
            {
                Console.WriteLine("OK");
            }
        }
        #endregion
    }
}
