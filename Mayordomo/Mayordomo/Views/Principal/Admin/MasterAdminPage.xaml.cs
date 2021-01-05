using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mayordomo.Views.Principal.Admin
{
    public partial class MasterAdminPage : MasterDetailPage
    {
        public MasterAdminPage()
        {
            InitializeComponent();
            App.Master = this;
        }
    }
}
