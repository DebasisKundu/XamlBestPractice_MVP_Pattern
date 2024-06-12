using System;
using Android.Content;
using GHouseMobile.Core.Controls;
using GHouseMobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GHRadioButton), typeof(CustomRadioButtonRenderer))]
namespace GHouseMobile.Droid.Renderers
{
    public class CustomRadioButtonRenderer : RadioButtonRenderer
    {
        public CustomRadioButtonRenderer(Context context) : base(context)
        {
        }

    }
}
