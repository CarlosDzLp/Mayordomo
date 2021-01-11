using Mayordomo.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]
namespace Mayordomo.iOS.Controls
{
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null)
                return;
            Control.Layer.CornerRadius = 0;
            Control.Layer.BorderWidth = 0;
            Control.ClipsToBounds = false;
        }
    }
}
