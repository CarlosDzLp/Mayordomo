using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Mayordomo.DataBases;
using Mayordomo.Models.Authenticate;
using Mayordomo.Models.User;
using Mayordomo.Models.WSResponse;
using Mayordomo.Services;
using Mayordomo.ViewModels.Base;
using Xamarin.Forms;

namespace Mayordomo.ViewModels.Session
{
    public class LoginPageViewModel : BindableBase
    {
        IServiceManager client = new ServiceManager();

        #region Properties
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion

        #region Constructor
        public LoginPageViewModel()
        {
#if DEBUG
            Email = "ryankar90@hotmail.com";
            Password = "Carlosdiaz90";
#endif
            LogInCommand = new Command(async () => await LogInCommandExecuted());
        }
        #endregion

        #region Command
        public ICommand LogInCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async Task LogInCommandExecuted()
        {
            try
            {
                if(string.IsNullOrWhiteSpace(Email))
                {
                    Snack("Ingrese un correo", "Mayordomo", Helpers.TypeSnackbar.Error);
                    return;
                }
                if(string.IsNullOrWhiteSpace(Password))
                {
                    Snack("Ingrese una contraseña", "Mayordomo", Helpers.TypeSnackbar.Error);
                    return;
                }
                var user = new UserModel()
                {
                    Email = Email,
                    Password = Password
                };
                Show("Obteniendo datos...");
                var deserializer = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                var response = await client.Post<Response<UserModel>>(deserializer, "api/authenticate/dologin");
                Hide();
                if (response != null)
                {
                    if (response.Result != null)
                    {
                        //SI HAY USUARIO Y DESPUES OBTIENE EL TOKEN
                        var responseToken = await client.Post<TokenResponse>(deserializer, "api/authenticate/aoth");
                        if(responseToken != null )
                        {
                            // SI HAY TOKEN E INGRESA AL DASHBOARD
                            responseToken.UserType = response.Result.UserType;
                            response.Result.Password = Password;
                            DbContext.Instance.InsertToken(responseToken);
                            DbContext.Instance.InsertUser(response.Result);
                            if(response.Result.UserType ==  1)
                            {
                                // ES ADMIN
                                App.Current.MainPage = new Views.Principal.Admin.MasterAdminPage();
                            }
                            else if(response.Result.UserType == 0)
                            {
                                //ES LIDER
                                App.Current.MainPage = new Views.Principal.Leader.MasterLeaderPage();
                            }
                            
                        }
                        else
                            Snack("Algo salio mal, intente mas tarde", "Mayordomo", Helpers.TypeSnackbar.Error);
                    }
                    else
                        Toast(response.Message);
                }
                else
                    Snack("Algo salio mal, intente mas tarde", "Mayordomo", Helpers.TypeSnackbar.Error);

                
            }
            catch(Exception ex)
            {
                Hide();
            }
        }
        #endregion
    }
}
