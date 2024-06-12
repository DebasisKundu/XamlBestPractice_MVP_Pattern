using System;
using Android.Content;
using GHouseMobile.Core.Controls;
using GHouseMobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GHDatePicker), typeof(CustomDatePickerRenderer))]
namespace GHouseMobile.Droid.Renderers
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        public CustomDatePickerRenderer(Context context):base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}
