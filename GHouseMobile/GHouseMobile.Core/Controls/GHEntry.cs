using Xamarin.Forms;

namespace GHouseMobile.Core.Controls
{
    public class GHEntry : Entry, IBaseControl
    {
        public static readonly BindableProperty IsBorderErrorVisibleProperty =
            BindableProperty.Create(nameof(IsBorderErrorVisible), typeof(bool), typeof(GHEntry), false, BindingMode.TwoWay);

        public bool IsBorderErrorVisible
        {
            get => (bool)GetValue(IsBorderErrorVisibleProperty);
            set => SetValue(IsBorderErrorVisibleProperty, value);
        }

        public static readonly BindableProperty BorderErrorColorProperty =
            BindableProperty.Create(nameof(BorderErrorColor), typeof(Color), typeof(GHEntry), Color.Red, BindingMode.TwoWay);

        public Color BorderErrorColor
        {
            get => (Color)GetValue(BorderErrorColorProperty);
            set => SetValue(BorderErrorColorProperty, value);
        }

        public static readonly BindableProperty ErrorTextProperty =
        BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(GHEntry), string.Empty);

        public string ErrorText
        {
            get => (string)GetValue(ErrorTextProperty);
            set => SetValue(ErrorTextProperty, value);
        }
    }
}

//TODO: UWP Renderer