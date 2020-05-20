using System;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using MayordomoApp.Controls;
using MayordomoApp.DataBase;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MayordomoApp
{
    public partial class App : Application
    {
        //CrossMediaManager.Current.MediaPlayer.AutoAttachVideoView = false;  se ajusta el video al reproductor
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public App()
        {
            InitializeComponent();
            var user = DbContext.Instance.GetUser();
            if (user != null)
            {
                MainPage = new NavigationViewPage(new Views.Principal.MasterPage());
            }
            else
            {
                MainPage = new NavigationPage(new Views.Session.LoginPage())
                {
                    BarTextColor = Color.White,
                    BarBackgroundColor = Color.FromHex("#1C2E29")
                };
            }
            OneSignal.Current.IdsAvailable(IdsAvailable);
            OneSignal.Current.StartInit("c2df8f3d-8733-47b2-87b3-9787310cecc3").InFocusDisplaying(OSInFocusDisplayOption.Notification).EndInit();

        }
        public async void IdsAvailable(string playerId, string pushToken)
        {
            //DbContext.Instance.InsertDeviceToken(playerId, pushToken);
        }
        //private async void load()
        //{
        //var item = await CrossMediaManager.Current.Extractor.CreateMediaItem("");
        //item.MediaType = MediaManager.Library.MediaType.Hls;
        //await CrossMediaManager.Current.Play(item);
        //}
        //<mm:VideoView VerticalOptions = "FillAndExpand" Source="http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4" />
        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
