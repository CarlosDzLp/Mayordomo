﻿using System;
using System.Threading.Tasks;
using GlobalToast;
using GlobalToast.Animation;
using Mayordomo.Helpers;
using Mayordomo.iOS.Helpers;
using SVProgressHUDBinding;
using TTGSnackBar;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Dialogs))]
namespace Mayordomo.iOS.Helpers
{
    public class Dialogs : IDialogs
    {
        public async Task Hide()
        {
            try
            {
                SVProgressHUD.Dismiss();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task Show(string message)
        {
            try
            {
                SVProgressHUD.SetDefaultStyle(SVProgressHUDStyle.Custom);
                SVProgressHUD.ShowWithMaskType(SVProgressHUDMaskType.Black);
                SVProgressHUD.SetDefaultMaskType(SVProgressHUDMaskType.Black);
                SVProgressHUD.SetDefaultAnimationType(SVProgressHUDAnimationType.Flat);
                UIView.AnimationsEnabled = true;
                SVProgressHUD.SetForegroundColor(UIKit.UIColor.Black);
                SVProgressHUD.Show();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task Snackbar(string message, string title, TypeSnackbar typeSnackbar)
        {
            var snackbar = new TTGSnackbar(message);
            if (typeSnackbar == TypeSnackbar.Success)
            {
                snackbar.MessageTextColor = UIKit.UIColor.White;
                snackbar.AnimationType = TTGSnackbarAnimationType.SlideFromBottomBackToBottom;
                snackbar.BackgroundColor = ColorHelper.FromHex("#1E9690");
                snackbar.BottomMargin = 0;
                snackbar.TopMargin = 0;
                snackbar.LeftMargin = 0;
                snackbar.RightMargin = 0;
                snackbar.MessageTextAlign = UITextAlignment.Center;
                snackbar.MessageMarginLeft = 20;
                snackbar.MessageMarginRight = 20;
                snackbar.Height = 150;
                snackbar.LocationType = TTGSnackbarLocation.Top;
                snackbar.CornerRadius = 0;
                snackbar.Show();
            }
            else
            {
                snackbar.MessageTextColor = UIKit.UIColor.White;
                snackbar.AnimationType = TTGSnackbarAnimationType.SlideFromBottomBackToBottom;
                snackbar.BackgroundColor = ColorHelper.FromHex("#F44336");
                snackbar.BottomMargin = 0;
                snackbar.TopMargin = 0;
                snackbar.LeftMargin = 0;
                snackbar.RightMargin = 0;
                snackbar.MessageMarginLeft = 20;
                snackbar.MessageMarginRight = 20;
                snackbar.Height = 100;
                snackbar.MessageTextAlign = UITextAlignment.Center;
                snackbar.LocationType = TTGSnackbarLocation.Top;
                snackbar.CornerRadius = 0;
                snackbar.Show();
            }
        }

        public async Task Toast(string message)
        {
            GlobalToast.Toast.MakeToast(message)
            .SetPosition(ToastPosition.Bottom)
            .SetDuration(ToastDuration.Long)
            .SetShowShadow(false)
            .SetAnimator(new ScaleAnimator())
            .SetBlockTouches(true)
            .SetAutoDismiss(true)
            .SetProgressIndicator(false)
            .Show();
        }
    }
}
