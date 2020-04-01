using System;
using MediaManager;
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

            MainPage = new NavigationPage(new Views.Session.LoginPage());

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
