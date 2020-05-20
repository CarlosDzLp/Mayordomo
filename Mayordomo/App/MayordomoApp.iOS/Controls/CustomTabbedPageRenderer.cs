using System;
using CoreGraphics;
using MayordomoApp.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
namespace MayordomoApp.iOS.Controls
{
    public class CustomTabbedPageRenderer : TabbedRenderer
    {
        UITabBarController tabbedController; TabbedPage tab;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                tabbedController = (UITabBarController)ViewController;
            }
            tab = (TabbedPage)e.NewElement;
        }

        public override void ViewWillAppear(bool animated)
        {
            if (base.ViewControllers != null)
            {
                UITabBar.Appearance.SelectionIndicatorImage =
                UndeLineColorPosition(tab.SelectedTabColor.ToUIColor(),
                new CGSize(UIScreen.MainScreen.Bounds.Width / base.ViewControllers.Length,
                tabbedController.TabBar.Bounds.Size.Height),
                new CGSize(UIScreen.MainScreen.Bounds.Width / base.ViewControllers.Length, 2));
            }
            UnselectedTitleColor();
            base.ViewWillAppear(animated);
        }

        UIImage UndeLineColorPosition(UIColor color, CGSize size, CGSize lineSize)
        {
            var rect = new CGRect(0, 0, size.Width, size.Height);
            var rectLine = new CGRect(0, size.Height - lineSize.Height, lineSize.Width, lineSize.Height);
            UIGraphics.BeginImageContextWithOptions(size, false, 0);
            UIColor.Clear.SetFill();
            UIGraphics.RectFill(rect); color.SetFill();
            UIGraphics.RectFill(rectLine);
            var img = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return img;
        }

        private void UnselectedTitleColor()
        {
            for (int i = 0; i < TabBar.Items.Length; i++)
            {
                TabBar.Items[i].SetTitleTextAttributes(new UITextAttributes { TextColor = tab.UnselectedTabColor.ToUIColor() },
                    UIControlState.Normal);
                TabBar.Items[i].SetTitleTextAttributes(new UITextAttributes { TextColor = tab.SelectedTabColor.ToUIColor(), },
                    UIControlState.Selected);
            }
        }
    }
}
