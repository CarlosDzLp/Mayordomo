using System;
using System.ComponentModel;
using Mayordomo.Fonts;
using Xamarin.Forms;

namespace Mayordomo.Triggers
{
    public class ShowPasswordTriggerAction : TriggerAction<ImageButton>, INotifyPropertyChanged
    {
        private FontImageSource ShowIcon { get; set; } = new FontImageSource()
        {
            Glyph = FontAwesome.Eye,
            Color = Color.Black,
            Size = 25,
            FontFamily = "Solid"
        };
        private FontImageSource HideIcon { get; set; } = new FontImageSource()
        {
            Glyph = FontAwesome.Hide,
            Color = Color.Black,
            Size = 25,
            FontFamily = "Regular"
        };
        bool _hidePassword = true;
        public bool HidePassword
        {
            set
            {
                if (_hidePassword != value)
                {
                    _hidePassword = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HidePassword)));
                }
            }
            get => _hidePassword;
        }
        protected override void Invoke(ImageButton sender)
        {
            sender.Source = HidePassword ? ShowIcon : HideIcon;
            HidePassword = !HidePassword;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
