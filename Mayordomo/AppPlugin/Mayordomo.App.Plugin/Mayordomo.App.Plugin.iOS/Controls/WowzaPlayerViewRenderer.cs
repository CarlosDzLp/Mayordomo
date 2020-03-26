using Mayordomo.App.Plugin.Controls;
using Mayordomo.App.Plugin.iOS.Controls;
using Plugin.WowzaClient;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WowzaPlayerView), typeof(WowzaPlayerViewRenderer))]
namespace Mayordomo.App.Plugin.iOS.Controls
{
    public class WowzaPlayerViewRenderer : ViewRenderer<WowzaPlayerView, UIView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WowzaPlayerView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new UIView());
            }

            if (e.NewElement != null)
            {
                WowzaClientManager.AttachPlayerView(Control);
            }
        }
    }
}