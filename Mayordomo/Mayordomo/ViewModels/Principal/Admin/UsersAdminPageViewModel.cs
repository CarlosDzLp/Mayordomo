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
            DeleteUserCommand = new Command<UserModel>(async(s) => await DeleteUserCommandExecuted(s));
            ActivatedUserCommand = new Command<UserModel>(async (s) => await ActivatedUserCommandExecuted(s));
        }
        #endregion

        #region Command
        public ICommand DeleteUserCommand { get; set; }
        public ICommand ActivatedUserCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async Task DeleteUserCommandExecuted(UserModel user)
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
        }
        private async Task ActivatedUserCommandExecuted(UserModel user)
        {
            try
            {

            }
            catch (Exception ex)
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
