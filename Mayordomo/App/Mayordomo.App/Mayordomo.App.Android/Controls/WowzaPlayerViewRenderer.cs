using Android.Content;
using Com.Wowza.Gocoder.Sdk.Api.Player;
using Mayordomo.App.Controls;
using Mayordomo.App.Droid.Controls;
using Plugin.WowzaClient;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WowzaPlayerView), typeof(WowzaPlayerViewRenderer))]
namespace Mayordomo.App.Droid.Controls
{
    public class WowzaPlayerViewRenderer : ViewRenderer<WowzaPlayerView, WOWZPlayerView>
    {
        public WowzaPlayerViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WowzaPlayerView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new WOWZPlayerView(Context));
            }

            if (e.NewElement != null)
            {
                WowzaClientManager.AttachPlayerView(Control);
            }
        }
    }
}