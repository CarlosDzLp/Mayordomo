using System;
using System.Collections.Generic;
using MayordomoApp.ViewModels.Base;
using Xamarin.Forms;

namespace MayordomoApp.Controls
{
    public partial class NavigationViewPage : NavigationPage
    {
        public NavigationViewPage()
        {
            InitializeComponent();
            this.BindingContext = new BindableBase();
        }
        public NavigationViewPage(Page root) : base(root)
        {
            InitializeComponent();
            this.BindingContext = new BindableBase();
        }
    }
}
