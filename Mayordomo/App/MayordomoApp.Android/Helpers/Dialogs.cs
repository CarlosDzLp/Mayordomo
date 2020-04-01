﻿using System;
using Dmax.Dialog;
using System.Threading.Tasks;
using Xamarin.Forms;
using MayordomoApp.Droid.Helpers;
using Plugin.CurrentActivity;
using Org.Aviran.CookieBar2;
using MayordomoApp.Helpers;
using Android.App;

[assembly: Dependency(typeof(Dialogs))]
namespace MayordomoApp.Droid.Helpers
{
    public class Dialogs : IDialogs
    {
        AlertDialog dialogAlert = null;
        public async Task Show(string message)
        {
            dialogAlert = new SpotsDialog.Builder().SetContext(CrossCurrentActivity.Current.Activity).SetMessage(message).SetCancelable(false)
                .Build();
            dialogAlert.Show();
        }

        public async Task Hide()
        {
            dialogAlert.Dismiss();
        }

        public async Task Snackbar(string message, string title, TypeSnackbar typeSnackbar)
        {
            if (typeSnackbar == TypeSnackbar.Success)
            {
                CookieBar.Build(CrossCurrentActivity.Current.Activity)
                .SetTitle(title)
                .SetBackgroundColor(Resource.Color.backgroundcoockiesuccess)
                .SetTitleColor(Resource.Color.cookiebartitle)
                .SetMessageColor(Resource.Color.cookiebartitle)
                .SetMessage(message)
                .SetEnableAutoDismiss(true)
                .SetSwipeToDismiss(true)
                .Show();
            }
            else
            {
                CookieBar.Build(CrossCurrentActivity.Current.Activity)
                .SetTitle(title)
                .SetBackgroundColor(Resource.Color.backgroundcoockieerror)
                .SetTitleColor(Resource.Color.cookiebartitle)
                .SetMessageColor(Resource.Color.cookiebartitle)
                .SetMessage(message)
                .SetEnableAutoDismiss(true)
                .SetSwipeToDismiss(true)
                .Show();
            }
        }

        public async Task Toast(string message)
        {
            var toast = Android.Widget.Toast.MakeText(CrossCurrentActivity.Current.Activity, message, Android.Widget.ToastLength.Short);
            toast.Show();
        }
    }
}
