using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mayordomo.Fonts;
using Mayordomo.Models.Admin;
using Mayordomo.ViewModels.Base;
using Xamarin.Forms;

namespace Mayordomo.ViewModels.Principal.Admin
{
    public class MenuAdminPageViewModel : BindableBase
    {
        #region Properties
        public ObservableCollection<MenuAdmin> ListMenu { get; set; }
        #endregion

        #region Constructor
        public MenuAdminPageViewModel()
        {
            _ = LoadMenu();
        }
        #endregion

        #region Methods
        public void Menu(MenuAdmin menu)
        {
            try
            {
                App.Master.IsPresented = false;
                if(menu.Title == "Inicio")
                {
                    App.Master.Detail.Navigation.PopToRootAsync(true);
                }
                else if(menu.Title == "Usuarios")
                {
                    App.Master.Detail.Navigation.PushAsync(new Views.Principal.Admin.Pages.UsersAdminPage());
                }
                else if(menu.Title == "Celulas")
                {
                    App.Master.Detail.Navigation.PushAsync(new Views.Principal.Admin.Pages.CelulasAdminPage());
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void ResetMenu(MenuAdmin menu)
        {
            try
            {
                foreach(var item in ListMenu)
                {
                    if (item.Title == menu.Title)
                        item.BackgroundColor = Color.FromHex("#2E2E2E");
                    else
                        item.BackgroundColor = Color.Black;
                }
            }
            catch(Exception ex)
            {

            }
        }
        private async Task LoadMenu()
        {
            try
            {
                ListMenu = new ObservableCollection<MenuAdmin>();
                ListMenu.Add(new MenuAdmin
                {
                    Title = "Inicio",
                    Img = FontAwesome.Home,
                    FontFamily = "LightPro",
                    BackgroundColor = Color.FromHex("#2E2E2E")
                });
                ListMenu.Add(new MenuAdmin
                {
                    Title = "Usuarios",
                    Img = FontAwesome.Users,
                    FontFamily = "Solid",
                    BackgroundColor = Color.Black
                });
                ListMenu.Add(new MenuAdmin
                {
                    Title = "Celulas",
                    Img = FontAwesome.Celula,
                    FontFamily = "Solid",
                    BackgroundColor = Color.Black
                });
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
