using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Mayordomo.DataBases;
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
        public async void Menu(MenuAdmin menu)
        {
            try
            {
                App.Master.IsPresented = false;
                if(menu.Title == "Inicio")
                {
                    await App.Master.Detail.Navigation.PopToRootAsync(true);
                }
                else if(menu.Title == "Usuarios")
                {
                    await App.Master.Detail.Navigation.PushAsync(new Views.Principal.Admin.Pages.UsersAdminPage());
                }
                else if(menu.Title == "Celulas")
                {
                    await App.Master.Detail.Navigation.PushAsync(new Views.Principal.Admin.Pages.CelulasAdminPage());
                }
                else if(menu.Title == "Cerrar sesión")
                {
                    var answer = await App.Master.DisplayAlert("Mayordomo", "Desea cerrar sesión", "Si", "No");
                    if(answer)
                    {
                        DbContext.Instance.DeleteUser();
                        DbContext.Instance.DeleteToken();
                        App.Current.MainPage = App.Navigation(new Views.Presentation.PresentationPage());
                    }
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
                if (menu.Title == "Cerrar sesión")
                    return;
                foreach (var item in ListMenu)
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
                ListMenu.Add(new MenuAdmin
                {
                    Title = "Cerrar sesión",
                    Img = "",
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
