using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GHouseMobile.Core.ViewModel;

using Xamarin.Forms;

namespace GHouseMobile.Core.Views
{
    public partial class RegisterView : ContentPage
    {
        public static int counter;

        public RegisterView()
        {
            InitializeComponent();
            counter = 1;
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            counter++;

            LoadFrame(counter);
        }

        private void LoadFrame(int frameCounter)
        {
            switch (frameCounter)
            {
                case 1:
                    GenderFrame.IsVisible = false;
                    PasswordFrame.IsVisible = false;
                    EmailFrame.IsVisible = false;
                    MobileFrame.IsVisible = false;
                    DOBFrame.IsVisible = true;
                    FrameAnimation(DOBFrame, -1);
                    GridNext.IsVisible = true;
                    GridSubmit.IsVisible = false;
                    break;

                case 2:
                    PasswordFrame.IsVisible = false;
                    EmailFrame.IsVisible = false;
                    MobileFrame.IsVisible = false;
                    DOBFrame.IsVisible = false;
                    GenderFrame.IsVisible = true;
                    FrameAnimation(GenderFrame, 1);
                    GridNext.IsVisible = true;
                    GridSubmit.IsVisible = false;
                    break;

                case 3:
                    EmailFrame.IsVisible = false;
                    MobileFrame.IsVisible = false;
                    DOBFrame.IsVisible = false;
                    GenderFrame.IsVisible = false;
                    PasswordFrame.IsVisible = true;
                    FrameAnimation(PasswordFrame, 1);
                    GridNext.IsVisible = true;
                    GridSubmit.IsVisible = false;
                    break;

                case 4:
                    MobileFrame.IsVisible = false;
                    DOBFrame.IsVisible = false;
                    GenderFrame.IsVisible = false;
                    PasswordFrame.IsVisible = false;
                    EmailFrame.IsVisible = true;
                    FrameAnimation(EmailFrame, 1);
                    GridNext.IsVisible = true;
                    GridSubmit.IsVisible = false;
                    break;

                case 5:
                    DOBFrame.IsVisible = false;
                    GenderFrame.IsVisible = false;
                    PasswordFrame.IsVisible = false;
                    EmailFrame.IsVisible = false;
                    MobileFrame.IsVisible = true;
                    FrameAnimation(MobileFrame, 1);
                    GridNext.IsVisible = false;
                    GridSubmit.IsVisible = true;
                    break;

                default:
                    counter = 1;
                    GenderFrame.IsVisible = false;
                    PasswordFrame.IsVisible = false;
                    EmailFrame.IsVisible = false;
                    MobileFrame.IsVisible = false;
                    DOBFrame.IsVisible = true;
                    FrameAnimation(DOBFrame, -1);
                    GridNext.IsVisible = true;
                    GridSubmit.IsVisible = false;
                    break;
            }
        }

        async void FrameAnimation(Frame frame, int direction)
        {
            frame.TranslationX = direction * 0.5;
            await Task.WhenAll(
        frame.TranslateTo(0, 0, 1, Easing.SinOut),
        frame.FadeTo(1,1));
        }
    }
}
