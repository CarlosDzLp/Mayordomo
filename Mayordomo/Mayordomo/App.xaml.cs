using System;
using Mayordomo.DataBases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mayordomo
{
    public partial class App : Application
    {
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public App()
        {
            InitializeComponent();
            //var user = DbContext.Instance.GetUser();
            //if (user != null)
            //{
            //    MainPage = new NavigationPage(new Views.Principal.MasterPage());
            //}
            //else
            //{
            MainPage = Navigation(new Views.Presentation.PresentationPage());
            //}
            //OneSignal.Current.IdsAvailable(IdsAvailable);
            //OneSignal.Current.StartInit("c2df8f3d-8733-47b2-87b3-9787310cecc3").InFocusDisplaying(OSInFocusDisplayOption.Notification).EndInit();

        }
        public static NavigationPage NavigationAsync { get; set; }

        public static NavigationPage Navigation(Page page)
        {
            return NavigationAsync = new NavigationPage(page)
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#1C2E29")
            };
        }

        public async void IdsAvailable(string playerId, string pushToken)
        {
            //DbContext.Instance.InsertDeviceToken(playerId, pushToken);
        }

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
