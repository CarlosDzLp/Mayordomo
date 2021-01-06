using System;
using System.Collections.Generic;
using Mayordomo.ViewModels.Principal.Admin;
using Xamarin.Forms;

namespace Mayordomo.Views.Principal.Admin
{
    public partial class DashboardAdminPage : ContentPage
    {
        DashboardAdminPageViewModel vm;
        public DashboardAdminPage()
        {
            InitializeComponent();
            this.BindingContext = vm = new DashboardAdminPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LoadUserInactive();
        }
    }
}
