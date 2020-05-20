using System;
using System.Windows.Input;
using MayordomoApp.Helpers;
using MayordomoApp.ViewModels.Base;
using Xamarin.Forms;

namespace MayordomoApp.ViewModels.Session
{
    public class RegisterPageViewModel : BindableBase
    {
        #region Properties
        public byte[] Photo{ get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        #endregion

        #region Constructor
        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(RegisterCommandExecuted);
            LoadPhotoCommand = new Command(LoadPhotoCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand RegisterCommand { get; set; }
        public ICommand LoadPhotoCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async void RegisterCommandExecuted()
        {
            try
            {
                if (Photo == null)
                {
                    Toast("Agregue una imagen");
                    return;
                }
                if (string.IsNullOrWhiteSpace(Name))
                {
                    Toast("Ingrese un nombre");
                    return;
                }
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    Toast("Ingrese sus apellidos");
                    return;
                }
                if (string.IsNullOrWhiteSpace(Phone))
                {
                    Toast("Ingrese un telefono");
                    return;
                }
                if (string.IsNullOrWhiteSpace(User))
                {
                    Toast("Ingrese un usuario");
                    return;
                }
                if (string.IsNullOrWhiteSpace(Password))
                {
                    Toast("Ingrese una contraseña");
                    return;
                }
                Show("Enviando datos......");
                //var responseemail = await client.Get<Response<UserModel>>($"user/useremail?email={Email}");
                Hide();

            }
            catch (Exception ex)
            {
                Hide();
                Toast(ex.Message);
            }
        }
        private async void LoadPhotoCommandExecuted()
        {
            string answer = await App.Current.MainPage.DisplayActionSheet("Notaria 23", "Cancelar", null, "Camara", "Galeria");
            if (!string.IsNullOrWhiteSpace(answer))
            {
                if (answer == "Galeria")
                {
                    var status = await Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Storage);
                    if (status)
                    {
                        Photo = await PhotoCamera.PickPhoto();
                    }
                    else
                    {
                        Toast("Habilite los permisos requeridos");
                    }
                }
                else if (answer == "Camara")
                {
                    var status = await Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Camera);
                    if (status)
                    {
                        Photo = await PhotoCamera.TakePhoto();
                    }
                    else
                    {
                        Toast("Habilite los permisos requeridos");
                    }
                }
            }
        }
        #endregion
    }
}
