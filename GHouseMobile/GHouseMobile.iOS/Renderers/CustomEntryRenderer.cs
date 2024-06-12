using System;
using System.ComponentModel;
using GHouseMobile.Core.Controls;
using GHouseMobile.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GHEntry), typeof(CustomEntryRenderer))]
namespace GHouseMobile.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            //if (Control != null)
            //{
            //    Control.BackgroundColor = UIColor.White;
            //}
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || this.Element == null)
                return;
            if (e.PropertyName == GHEntry.IsBorderErrorVisibleProperty.PropertyName)
            {
                if (((GHEntry)this.Element).IsBorderErrorVisible)
                {
                    this.Control.Layer.BorderColor = ((GHEntry)this.Element).BorderErrorColor.ToCGColor();
                    this.Control.Layer.BorderWidth = new nfloat(0.8);
                }
                else
                {
                    this.Control.Layer.BorderColor = UIColor.LightGray.CGColor;
                    this.Control.Layer.BorderWidth = new nfloat(0.8);
                }
            }
        }
    }
}
