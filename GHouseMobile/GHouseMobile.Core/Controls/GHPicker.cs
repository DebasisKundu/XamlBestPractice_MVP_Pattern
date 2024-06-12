using Xamarin.Forms;

namespace GHouseMobile.Core.Controls
{
    public class GHPicker:Picker
    {
		public static readonly BindableProperty ImageProperty =
			BindableProperty.Create(nameof(Image), typeof(string), typeof(GHPicker), string.Empty);

		public string Image
		{
			get { return (string)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}
	}
}

//TODO: UWP Renderer