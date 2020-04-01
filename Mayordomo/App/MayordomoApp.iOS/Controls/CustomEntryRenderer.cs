using System;
using MayordomoApp.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace MayordomoApp.iOS.Controls
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control.Layer.CornerRadius = 0;
            Control.BorderStyle = UIKit.UITextBorderStyle.None;
            Control.Layer.BorderWidth = 0;
            Control.ClipsToBounds = false;
        }
    }
}
