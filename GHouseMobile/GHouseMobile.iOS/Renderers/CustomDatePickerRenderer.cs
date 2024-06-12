using System;
using GHouseMobile.Core.Controls;
using GHouseMobile.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GHDatePicker), typeof(CustomDatePickerRenderer))]
namespace GHouseMobile.iOS.Renderers
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BackgroundColor = UIColor.White;
            }
        }
    }
}
