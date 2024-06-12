using System;
using GHouseMobile.Core.Controls;
using GHouseMobile.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GHPicker), typeof(CustomPickerRenderer))]
namespace GHouseMobile.iOS.Renderers
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            var element = (GHPicker)this.Element;

            if (this.Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))
            {
                var downarrow = UIImage.FromBundle(element.Image);
                Control.RightViewMode = UITextFieldViewMode.Always;
                Control.RightView = new UIImageView(downarrow);
            }
            else if (this.Control != null)
                Control.BackgroundColor = UIColor.White;
        }
    }
}
