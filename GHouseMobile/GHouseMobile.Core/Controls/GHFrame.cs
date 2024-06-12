using System;
using System.Runtime.CompilerServices;
using GHouseMobile.Core.Enums;
using GHouseMobile.Core.Helpers;
using Xamarin.Forms;

namespace GHouseMobile.Core.Controls
{
    public class GHFrame : Frame
    {
        public GHFrame()
        {
            HasShadow = false;
            BackgroundColor = Color.White;
            Padding = new Thickness(0);
        }

        public static readonly BindableProperty IsScaleAnimationProperty =
            BindableProperty.Create(nameof(ScaleAnimation), typeof(bool), typeof(GHFrame), false);

        public bool ScaleAnimation
        {
            get { return (bool)GetValue(IsScaleAnimationProperty); }
            set { SetValue(IsScaleAnimationProperty, value); }
        }

        public static readonly BindableProperty FrameBorderProperty =
            BindableProperty.Create(nameof(FrameBorder), typeof(Color), typeof(GHFrame), Color.LightGray);

        public Color FrameBorder
        {
            get { return (Color)GetValue(FrameBorderProperty); }
            set { SetValue(FrameBorderProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (this.ScaleAnimation)
            {
                AnimationHelper.ScaleFrame(this);
            }
            BorderColor = FrameBorder;
        }
    }
}
