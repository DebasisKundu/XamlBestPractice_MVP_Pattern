using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GHouseMobile.Core.Controls;
using GHouseMobile.Core.Enums;
using GHouseMobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.FastRenderers;

[assembly: ExportRenderer(typeof(GHGradientView),typeof(GradientViewRenderer))]
namespace GHouseMobile.Droid.Renderers
{
    public class GradientViewRenderer : VisualElementRenderer<GHGradientView>
    {
        public GradientViewRenderer(Context context) : base(context)
        {
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            var box = Element;

            var gradient = new LinearGradient(0, 0,
                                              box.Direction == GradientDirection.Horizontal ? Width : 0,
                                              box.Direction == GradientDirection.Vertical ? Height : 0,
                                              box.InitialColor.ToAndroid(),
                                              box.FinalColor.ToAndroid(),
                                              Shader.TileMode.Mirror);

            var paint = new Paint()
            {
                Dither = true,
            };

            paint.SetShader(gradient);
            canvas.DrawPaint(paint);

            base.DispatchDraw(canvas);
        }
    }
}