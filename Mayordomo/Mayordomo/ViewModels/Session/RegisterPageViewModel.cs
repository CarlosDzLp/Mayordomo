using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Mayordomo.Helpers;
using Mayordomo.Models.User;
using Mayordomo.Models.WSResponse;
using Mayordomo.Services;
using Mayordomo.ViewModels.Base;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mayordomo.ViewModels.Session
{
    public class RegisterPageViewModel : BindableBase
    {
        IServiceManager client = new ServiceManager();
        #region Properties
        public byte[] Photo { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        #endregion

        #region Constructor
        public RegisterPageViewModel(string email)
        {
            Email = email;
            RegisterCommand = new Command(async () => await RegisterCommandExecuted());
            LoadPhotoCommand = new Command(LoadPhotoCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand RegisterCommand { get; set; }
        public ICommand LoadPhotoCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async Task RegisterCommandExecuted()
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
                if (string.IsNullOrWhiteSpace(Email))
                {
                    Toast("Ingrese un usuario");
                    return;
                }
                if (string.IsNullOrWhiteSpace(Password))
                {
                    Toast("Ingrese una contraseña");
                    return;
                }

                var user = new UserModel()
                {
                    Address = Address,
                    Email = Email,
                    LastName = LastName,
                    Name = Name,
                    Password = Password,
                    Status = false,
                    UserType = 0,
                    PhotoBytes = Photo
                };
                var serializer = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                Show("Enviando datos......");
                var responseInsertUser = await client.Post<Response<bool>>(serializer, "api/authenticate/insertuser");
                Hide();
                if (responseInsertUser != null)
                {
                    if(responseInsertUser.Result)
                    {
                        Snack("Se agrego correctamente, espere a que un administrador le de acceso", "Mayordomo", TypeSnackbar.Success);
                        await App.NavigationAsync.Navigation.PopToRootAsync(true);
                    }
                }
                else
                {
                    Toast("Hubo un error intente mas tarde");
                }
                

            }
            catch (Exception ex)
            {
                Hide();
                Toast(ex.Message);
            }
        }
        private async void LoadPhotoCommandExecuted()
        {
            try
            {
                string answer = await App.Current.MainPage.DisplayActionSheet("Mayordomo", "Cancelar", null, "Camara", "Galeria");
                if (!string.IsNullOrWhiteSpace(answer))
                {
                    if (answer == "Galeria")
                    {
                        var status = await Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Storage);
                        if (status)
                        {
                            var camera = await Xamarin.Essentials.MediaPicker.PickPhotoAsync(new MediaPickerOptions() { Title = "test" });
                            var stream = await camera.OpenReadAsync();
                            if (stream != null)
                            {
                                Photo = ReadFully(stream);
                            }
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
                            var pickphoto = await Xamarin.Essentials.MediaPicker.CapturePhotoAsync(new MediaPickerOptions() { Title = "test" });
                            var stream = await pickphoto.OpenReadAsync();
                            if (stream != null)
                            {
                                Photo = ReadFully(stream);
                            }
                        }
                        else
                        {
                            Toast("Habilite los permisos requeridos");
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
        #endregion
    }
}
