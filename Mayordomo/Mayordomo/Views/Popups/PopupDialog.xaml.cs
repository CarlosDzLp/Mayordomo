using Mayordomo.Enums;
using Rg.Plugins.Popup.Services;

namespace Mayordomo.Views.Popups
{
    public partial class PopupDialog : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupDialog(string message, PopupDialogsEnum dialogsEnum)
        {
            InitializeComponent();
            DataPopup(message, dialogsEnum);
        }

        #region Methods
        private void DataPopup(string message, PopupDialogsEnum dialogsEnum)
        {
            lblmessage.Text = message;
            if (dialogsEnum == PopupDialogsEnum.Success)
                lottieanimation.Animation = "success.json";
            else if (dialogsEnum == PopupDialogsEnum.Error)
                lottieanimation.Animation = "error.json";
            else if (dialogsEnum == PopupDialogsEnum.Delete)
                lottieanimation.Animation = "delete.json";
            else if (dialogsEnum == PopupDialogsEnum.Info)
                lottieanimation.Animation = "info.json";
            else if (dialogsEnum == PopupDialogsEnum.Question)
                lottieanimation.Animation = "question.json";
        }
        #endregion

        #region Handlers
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.RemovePageAsync(this, true);
        }
        #endregion
    }
}
