using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using GHouseMobile.Core.Controls;
using GHouseMobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GHEntry), typeof(CustomEntryRenderer))]
namespace GHouseMobile.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            //if (Control != null)
            //{
            //    Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            //}
            UpdateBorderShape();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null)
                return;
            if (e.PropertyName == GHEntry.IsBorderErrorVisibleProperty.PropertyName)
                UpdateBorderShape();
        }

        void UpdateBorderShape()
        {
            GradientDrawable shape = new GradientDrawable();
            shape.SetShape(ShapeType.Rectangle);
            shape.SetCornerRadius(0);

            if (((GHEntry)this.Element).IsBorderErrorVisible)
            {
                shape.SetStroke(3, ((GHEntry)this.Element).BorderErrorColor.ToAndroid());
            }
            else
            {
                shape.SetStroke(3, Android.Graphics.Color.LightGray);
                this.Control.SetBackground(shape);
            }

            this.Control.SetBackground(shape);
        }

    }
}
