using System;
using Mayordomo.DataBases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mayordomo
{
    public partial class App : Application
    {
        public static MasterDetailPage Master { get; set; }

        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] {
                "SwipeView_Experimental"
            });
            var token = DbContext.Instance.GetToken();
            if (token != null)
            {
                if (token.UserType == 1)
                    MainPage = new Views.Principal.Admin.MasterAdminPage();
                else if (token.UserType == 0)
                    MainPage = new Views.Principal.Leader.MasterLeaderPage();
            }
            else
            {
                MainPage = Navigation(new Views.Presentation.PresentationPage());
            }
            //OneSignal.Current.IdsAvailable(IdsAvailable);
            //OneSignal.Current.StartInit("c2df8f3d-8733-47b2-87b3-9787310cecc3").InFocusDisplaying(OSInFocusDisplayOption.Notification).EndInit();

        }
        public static NavigationPage NavigationAsync { get; set; }

        public static NavigationPage Navigation(Page page)
        {
            return NavigationAsync = new NavigationPage(page)
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.Black
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
