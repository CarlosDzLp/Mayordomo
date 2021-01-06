using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mayordomo.DataBases;
using Mayordomo.Models.User;
using Mayordomo.Models.WSResponse;
using Mayordomo.Services;
using Mayordomo.ViewModels.Base;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Mayordomo.ViewModels.Principal.Admin
{
    public class DashboardAdminPageViewModel : BindableBase
    {
        IServiceManager client = new ServiceManager();

        #region Properties
        public bool IsVisibleSuccess { get; set; }
        public bool IsVisibleUser { get; set; }
        public int CountUser { get; set; } = 0;
        #endregion

        #region Constructor
        public DashboardAdminPageViewModel()
        {

        }
        #endregion

        #region Methods
        public void LoadUserInactive()
        {
            try
            {
                Task.Run(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var response = await client.Get<Response<List<UserModel>>>("api/login/alluser", DbContext.Instance.GetToken().Token);
                        if (response != null && response.Result != null && response.Result.Count > 0)
                        {
                            IsVisibleUser = true;
                            IsVisibleSuccess = false;
                            CountUser = response.Result.Count;
                        }
                        else
                        {
                            IsVisibleUser = false;
                            IsVisibleSuccess = true;
                        }
                    });
                });
            }
            catch(Exception ex)
            {
                IsVisibleUser = false;
                IsVisibleSuccess = true;
            }
        }
        #endregion
    }
}
