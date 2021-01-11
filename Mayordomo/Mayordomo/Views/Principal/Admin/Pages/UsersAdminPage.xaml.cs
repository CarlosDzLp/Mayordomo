using System;
using System.Collections.Generic;
using Mayordomo.ViewModels.Principal.Admin;
using Xamarin.Forms;

namespace Mayordomo.Views.Principal.Admin.Pages
{
    public partial class UsersAdminPage : ContentPage
    {
        public UsersAdminPage()
        {
            InitializeComponent();
            this.BindingContext = new UsersAdminPageViewModel();
        }
    }
}
