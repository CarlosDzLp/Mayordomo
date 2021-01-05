using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Mayordomo.Helpers;
using Mayordomo.Models.WSResponse;
using Mayordomo.Services;
using Mayordomo.ViewModels.Base;
using Xamarin.Forms;

namespace Mayordomo.ViewModels.Session
{
    public class EmailValidatePageViewModel : BindableBase
    {
        IServiceManager client = new ServiceManager();

        #region Properties
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if(_email != value)
                {
                    SetProperty(ref _email, value);
                    OnValidateEmail();
                }
            }
        }
        public Color Color { get; set; } = Color.Black;
        public bool IsEnabled { get; set; }
        #endregion

        #region Constructor
        public EmailValidatePageViewModel()
        {
            ValidateEmailCommand = new Command(async () => await ValidateEmailCommandExecuted());
        }
        #endregion

        #region Command
        public ICommand ValidateEmailCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async Task ValidateEmailCommandExecuted()
        {
            try
            {
                Show("Obteniendo datos...");
                var response = await client.Get<Response<bool>>($"api/authenticate/validateemail?email={Email}");
                Hide();
                if (response != null)
                {
                    if(!response.Result && response.Count == 0)
                    {
                        //NO HAY CORREO REGISTRADO
                        await App.NavigationAsync.PushAsync(new Views.Session.RegisterPage(Email));
                    }
                    else
                    {
                        Snack(response.Message,"Mayordomo" ,TypeSnackbar.Error);
                    }
                }
                else
                    Toast("Algo salio mal, intente mas tarde");
            }
            catch(Exception ex)
            {
                Hide();
            }
        }
        #endregion

        #region Methods
        private void OnValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                IsEnabled = false;
                Color = Color.Red;
                return;
            }
                
            if(RegexUtilities.IsValidEmail(Email))
            {
                Color = Color.Black;
                IsEnabled = true;
            }
            else
            {
                Color = Color.Red;
                IsEnabled = false;
            }
        }
        #endregion
    }
}
