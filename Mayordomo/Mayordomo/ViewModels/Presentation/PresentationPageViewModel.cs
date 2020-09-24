using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Mayordomo.ViewModels.Base;
using Mayordomo.Models.Presentation;
using Xamarin.Forms;

namespace Mayordomo.ViewModels.Presentation
{
    public class PresentationPageViewModel : BindableBase
    {
        #region Properties
        public ObservableCollection<BannerModel> ListBanner { get; set; }
        #endregion

        #region Constructor
        public PresentationPageViewModel()
        {
            LoadBanner();
            LoginPageCommand = new Command(LoginPageCommandExecuted);
            RegisterPageCommand = new Command(RegisterPageCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand LoginPageCommand { get; set; }
        public ICommand RegisterPageCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void RegisterPageCommandExecuted()
        {
            App.NavigationAsync.PushAsync(new Views.Session.RegisterPage());
        }

        private void LoginPageCommandExecuted()
        {
            App.NavigationAsync.PushAsync(new Views.Session.LoginPage());
        }
        #endregion

        #region Methods
        private void LoadBanner()
        {
            try
            {
                ListBanner = new ObservableCollection<BannerModel>();
                ListBanner.Clear();
                ListBanner.Add(new BannerModel { Id = 0, Image = "", Title = "" });
                ListBanner.Add(new BannerModel { Id = 0, Image = "", Title = "" });
                ListBanner.Add(new BannerModel { Id = 0, Image = "", Title = "" });
                ListBanner.Add(new BannerModel { Id = 0, Image = "", Title = "" });
                ListBanner.Add(new BannerModel { Id = 0, Image = "", Title = "" });
                ListBanner.Add(new BannerModel { Id = 0, Image = "", Title = "" });
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
