using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.CurrentActivity;
using FormsToolkit;
using MayordomoApp.Helpers;
using Android.Support.V4.App;
using Android;

namespace MayordomoApp.Droid
{
    [Activity(Label = "MayordomoApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            LoadApplication(new App());
            MessagingService.Current.Subscribe<MessageKeys>("StatusBar", (args, sender) =>
            {
                if (sender.StatusBarTransparent)
                {
                    setLightStatusBar(this, Android.Graphics.Color.White);
                }
                else
                {
                    ClearLightStatusBar(this, sender.ColorHex);
                }
            });
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public void setLightStatusBar(Activity activity, Android.Graphics.Color color)
        {
            int flags = (int)activity.Window.DecorView.SystemUiVisibility; // get current flag
            flags |= (int)SystemUiFlags.LightStatusBar;   // add LIGHT_STATUS_BAR to flag
            activity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)flags;
            activity.Window.SetStatusBarColor(color);
        }
        public void ClearLightStatusBar(Activity activity, string colorHex)//Android.Graphics.Color color)
        {
            int newUiVisibility = (int)activity.Window.DecorView.SystemUiVisibility;
            newUiVisibility &= ~(int)Android.Views.SystemUiFlags.LightStatusBar;
            activity.Window.DecorView.SystemUiVisibility = (Android.Views.StatusBarVisibility)newUiVisibility;
            activity.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor(colorHex));
        }


        private void GetPermissions()
        {
            try
            {
                ActivityCompat.RequestPermissions(this, new string[]
                {
                    Manifest.Permission.Camera,
                    Manifest.Permission.ReadExternalStorage,
                    Manifest.Permission.WriteExternalStorage,
                }, 0);
            }
            catch
            {

            }
        }

        public override void OnBackPressed()
        {
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                //Debug.WriteLine("Android back button: There are some pages in the PopupStack");
            }
            else
            {
                //Debug.WriteLine("Android back button: There are not any pages in the PopupStack");
            }
        }
    }
}