using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using GHouseMobile.Core.Controls;
using GHouseMobile.Core.Enums;
using GHouseMobile.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GHGradientView), typeof(GradientViewRenderer))]
namespace GHouseMobile.iOS.Renderers
{
    public class GradientViewRenderer : VisualElementRenderer<GHGradientView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<GHGradientView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
                SetNeedsDisplay();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            SetNeedsDisplay();
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            if (Element == null)
                return;

            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new CGColor[]
            {
                Element.InitialColor.ToCGColor(),
                Element.FinalColor.ToCGColor()
            };

            if (Element.Direction == GradientDirection.Vertical)
            {
                gradientLayer.StartPoint = new CGPoint(0.5, 0);
                gradientLayer.EndPoint = new CGPoint(0.5, 1);
            }
            else
            {
                gradientLayer.StartPoint = new CGPoint(0, 0.5);
                gradientLayer.EndPoint = new CGPoint(1, 0.5);
            }

            gradientLayer.Frame = rect;
            if (NativeView.Layer.Sublayers != null)
            {
                foreach (var subLayer in NativeView.Layer.Sublayers)
                {
                    subLayer.RemoveFromSuperLayer();
                }
            }
            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}