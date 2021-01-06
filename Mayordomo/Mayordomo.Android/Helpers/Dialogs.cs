using System;
using System.Threading.Tasks;
using Mayordomo.Droid.Helpers;
using Mayordomo.Helpers;
using Org.Aviran.CookieBar2;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(Dialogs))]
namespace Mayordomo.Droid.Helpers
{
    public class Dialogs : IDialogs
    {
        //AlertDialog dialogAlert = null;
        public async Task Show(string message)
        {
            try
            {
                AndroidHUD.AndHUD.Shared.Show(CrossCurrentActivity.Current.Activity, message, -1, AndroidHUD.MaskType.Black, centered: true);
            }
            catch(Exception ex)
            {

            }
        }

        public async Task Hide()
        {
            try
            {
                AndroidHUD.AndHUD.Shared.Dismiss(CrossCurrentActivity.Current.Activity);
            }
            catch(Exception ex)
            {

            }
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
