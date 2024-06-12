using GHouseMobile.Core.Controls;
using GHouseMobile.Core.Enums;
using GHouseMobile.UWP.Renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Panel = Windows.UI.Xaml.Controls.Panel;
using Point = Windows.Foundation.Point;

[assembly: ExportRenderer(typeof(GHGradientView), typeof(GradientViewRenderer))]
namespace GHouseMobile.UWP.Renderers
{
    public class GradientViewRenderer : VisualElementRenderer<GHGradientView, FrameworkElement>
    {

        protected override void UpdateBackgroundColor()
        {
            base.UpdateBackgroundColor();

            if (Element == null)
                return;

            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            if (Element.Direction == GradientDirection.Vertical)
            {
                gradientBrush.StartPoint = new Point(0.5, 0);
                gradientBrush.EndPoint = new Point(0.5, 1);
            }
            else
            {
                gradientBrush.StartPoint = new Point(0, 0.5);
                gradientBrush.EndPoint = new Point(1, 0.5);
            }

            gradientBrush.GradientStops.Add(
                new GradientStop() { Color = Element.InitialColor.ToWindowsColor(), Offset = 0 });
            gradientBrush.GradientStops.Add(
                new GradientStop() { Color = Element.FinalColor.ToWindowsColor(), Offset = 0.5 });
            gradientBrush.GradientStops.Add(
                new GradientStop() { Color = Element.InitialColor.ToWindowsColor(), Offset = 1 });

            Background = gradientBrush;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<GHGradientView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
                UpdateBackgroundColor();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            UpdateBackgroundColor();
        }
    }
}
