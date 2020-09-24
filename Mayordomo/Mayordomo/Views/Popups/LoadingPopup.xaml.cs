namespace Mayordomo.Views.Popups
{
    public partial class LoadingPopup : Rg.Plugins.Popup.Pages.PopupPage
    {   
        public LoadingPopup(string message)
        {
            InitializeComponent();
            lblmessage.Text = message;
        }
    }
}
