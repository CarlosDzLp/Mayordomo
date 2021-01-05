using System;
using System.Collections.Generic;
using Mayordomo.Models.Admin;
using Mayordomo.ViewModels.Principal.Admin;
using Xamarin.Forms;

namespace Mayordomo.Views.Principal.Admin
{
    public partial class MenuAdminPage : ContentPage
    {
        MenuAdminPageViewModel vm;
        public MenuAdminPage()
        {
            InitializeComponent();
            this.BindingContext = vm = new MenuAdminPageViewModel();
        }

        void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            try
            {
                if(e.CurrentSelection.Count > 0)
                {
                    var item = e.CurrentSelection[0] as MenuAdmin;
                    if(item != null)
                    {
                        vm.ResetMenu(item);
                        vm.Menu(item);
                        ((CollectionView)sender).SelectedItem = null;
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
