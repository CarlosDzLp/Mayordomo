using Mayordomo.App.Controls;
using Mayordomo.App.iOS.Controls;
using Plugin.WowzaClient;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WowzaPlayerView), typeof(WowzaPlayerViewRenderer))]
namespace Mayordomo.App.iOS.Controls
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