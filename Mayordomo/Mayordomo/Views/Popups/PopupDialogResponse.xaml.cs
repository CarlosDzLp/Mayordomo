﻿using System;
using Mayordomo.Enums;
using Rg.Plugins.Popup.Services;

namespace Mayordomo.Views.Popups
{
    public partial class PopupDialogResponse : Rg.Plugins.Popup.Pages.PopupPage
    {
        public event EventHandler<PopupState> PopupResponse;
        public PopupDialogResponse(string message,string btntext, PopupDialogsEnum dialogsEnum)
        {
            InitializeComponent();
            DataPopup(message, btntext, dialogsEnum);
        }

        #region Methods
        private void DataPopup(string message,string btntext, PopupDialogsEnum dialogsEnum)
        {
            lblmessage.Text = message;
            btn.Text = btntext;
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
        void ButtonCancelClicked(System.Object sender, System.EventArgs e)
        {
            PopupResponse?.Invoke(this, PopupState.Cancel);
            PopupNavigation.Instance.RemovePageAsync(this, true);
        }

        void ButtonOkClicked(System.Object sender, System.EventArgs e)
        {
            PopupResponse?.Invoke(this, PopupState.Ok);
            PopupNavigation.Instance.RemovePageAsync(this, true);
        }
        #endregion
    }
}