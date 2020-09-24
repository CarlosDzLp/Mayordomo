using System;
using Xamarin.Forms;

namespace Mayordomo.Controls
{
    public class FloatingEntry : Entry
    {
        public static readonly BindableProperty ActivePlaceholderColorProperty = BindableProperty.Create(nameof(ActivePlaceholderColor),
            typeof(Color),
            typeof(FloatingEntry),
            Color.Accent);

        public static readonly BindableProperty FloatingHintEnabledProperty = BindableProperty.Create(nameof(FloatingHintEnabled),
            typeof(bool),
            typeof(FloatingEntry),
            true);

        public Color ActivePlaceholderColor
        {
            get => (Color)GetValue(ActivePlaceholderColorProperty);
            set => SetValue(ActivePlaceholderColorProperty, value);
        }

        public bool FloatingHintEnabled
        {
            get => (bool)GetValue(FloatingHintEnabledProperty);
            set => SetValue(FloatingHintEnabledProperty, value);
        }

    }
}
