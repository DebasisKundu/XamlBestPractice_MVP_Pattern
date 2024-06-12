using System;
using GHouseMobile.Core.Enums;
using Xamarin.Forms;

namespace GHouseMobile.Core.Helpers
{
    public static class AnimationHelper
    {
        public static void ScaleFrame(Frame frame)
        {
            var animation = new Animation(v => frame.Scale = v, GHConstants.Animation.LowerBound, GHConstants.Animation.UpperBound);
            animation.Commit(frame, AnimationType.ScaleIt.ToString(),
                length: GHConstants.Animation.Duration,
                easing: Easing.Linear,
                finished: (v, c) => frame.Scale = GHConstants.Animation.UpperBound, repeat: () => false);
        }
    }
}
