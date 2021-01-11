using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Mayordomo.DataBases;
using Mayordomo.Models.User;
using Mayordomo.Models.WSResponse;
using Mayordomo.Services;
using Mayordomo.ViewModels.Base;
using Mayordomo.Views.Popups;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Mayordomo.ViewModels.Principal.Admin
{
    public class UsersAdminPageViewModel : BindableBase
    {
        IServiceManager client = new ServiceManager();

        #region Properties
        public ObservableCollection<UserModel> ListUser { get; set; }
        public bool IsVisibleEmpty { get; set; }
        public bool IsVisibleList { get; set; }
        #endregion

        #region Constructor
        public UsersAdminPageViewModel()
        {
            _ = LoadUser();
            DeleteUserCommand = new Command<UserModel>(DeleteUserCommandExecuted);
            ActivatedUserCommand = new Command<UserModel>(ActivatedUserCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand DeleteUserCommand { get; set; }
        public ICommand ActivatedUserCommand { get; set; }
        #endregion

        #region CommandExecuted
        private PopupDialogResponse popup = null;
        private UserModel Delete { get; set; }
        private void DeleteUserCommandExecuted(UserModel user)
        {
            try
            {
                if (user == null)
                    return;
                Delete = user;
                popup = new PopupDialogResponse("¿Desea eliminar este usuario?"
                    , "Eliminar", Enums.PopupDialogsEnum.Delete);
                popup.PopupResponse += PopupPopupResponseDelete;
                PopupNavigation.Instance.PushAsync(popup);
            }
            catch(Exception ex)
            {

            }
        }

        private async void PopupPopupResponseDelete(object sender, Enums.PopupState e)
        {
            try
            {
                popup.PopupResponse -= PopupPopupResponseDelete;
                if(e == Enums.PopupState.Ok)
                {
                    var token = DbContext.Instance.GetToken();
                    var response = await client.Delete<Response<bool>>($"api/login/DeleteAccount?IdUser={Delete.IdUser}", token.Token);
                    if(response != null)
                    {
                        if(response.Result)
                        {
                            Snack("Se ha eliminado correctamente", "Mayordomo", Helpers.TypeSnackbar.Success);
                            await LoadUser();
                        }
                        else
                        {
                            Toast(response.Message);
                        }
                    }
                    else
                    {
                        Snack("Hubo un error intente mas tarde", "Mayordomo", Helpers.TypeSnackbar.Error);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void ActivatedUserCommandExecuted(UserModel user)
        {
            try
            {
                if (user == null)
                    return;
                popup = new PopupDialogResponse("¿Desea activar este usuario?"
                    , "Activar", Enums.PopupDialogsEnum.Question, "https://post.healthline.com/wp-content/uploads/2020/05/435791-Forget-You-Have-Plants-11-Types-That-Will-Forgive-You_Thumnail.jpg");
                popup.PopupResponse += PopupPopupResponseActivate;
                PopupNavigation.Instance.PushAsync(popup);
            }
            catch (Exception ex)
            {

            }
        }

        private void PopupPopupResponseActivate(object sender, Enums.PopupState e)
        {
            try
            {
                popup.PopupResponse -= PopupPopupResponseActivate;
                if (e == Enums.PopupState.Ok)
                {

                }
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region Methods
        private async Task LoadUser()
        {
            try
            {
                ListUser = new ObservableCollection<UserModel>();
                ListUser.Clear();
                Show("Obteniendo datos...");
                var response = await client.Get<Response<List<UserModel>>>("api/login/alluser", DbContext.Instance.GetToken().Token);
                Hide();
                if (response != null && response.Result != null && response.Result.Count > 0)
                {
                    IsVisibleList = true;
                    IsVisibleEmpty = false;

                    foreach(var item in response.Result)
                    {
                        ListUser.Add(item);
                    }
                }
                else
                {
                    IsVisibleEmpty = true;
                    IsVisibleList = false;
                    Toast("Hubo un error, intente mas tarde");
                }
            }
            catch (Exception ex)
            {
                Hide();
            }
        }
        #endregion
    }
}
