using System;
using System.Windows;
using Dartware.Radiocamp.Clients.Windows.UI.Animation;

namespace Dartware.Radiocamp.Clients.Windows.UI.AttachedProperties
{
	public class AnimateSlideInFromBottomOnLoad : AnimateBaseProperty<AnimateSlideInFromBottomOnLoad>
    {
        protected override async void DoAnimation(FrameworkElement element, Boolean value, Boolean firstLoad)
        {
            await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, !value, !value ? 0 : 0.2F, keepMargin: false);
        }
    }
}