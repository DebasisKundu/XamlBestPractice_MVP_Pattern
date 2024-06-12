using GHouseMobile.Core.Enums;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GHouseMobile.Core.Controls
{
    public class GHGradientView : View, IBaseControl
    {
        public static readonly BindableProperty InitialColorProperty = BindableProperty.Create(
            "InitialColor", typeof(Color), typeof(GHGradientView), default(Color)
            );
        public Color InitialColor
        {
            get { return (Color)GetValue(InitialColorProperty); }
            set { SetValue(InitialColorProperty, value); }
        }

        public static readonly BindableProperty FinalColorProperty = BindableProperty.Create(
           "FinalColor", typeof(Color), typeof(GHGradientView), default(Color)
            );
        public Color FinalColor
        {
            get { return (Color)GetValue(FinalColorProperty); }
            set { SetValue(FinalColorProperty, value); }
        }

        public static readonly BindableProperty DirectionProperty = BindableProperty.Create(
           "Direction", typeof(GradientDirection), typeof(GHGradientView), default(GradientDirection)
            );
        public GradientDirection Direction
        {
            get { return (GradientDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
           "Text", typeof(string), typeof(GHGradientView), default(string)
            );

        public string Text {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty,value);
        }
    }
}
