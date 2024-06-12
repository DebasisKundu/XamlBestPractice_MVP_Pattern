using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GHouseMobile.Core.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GHGradientButton : IBaseControl
    {
        public GHGradientButton()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            "Text",
            typeof(string),
            typeof(GHGradientButton),
            default(string));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
      
    }
}