using System;
using System.Windows;
using Dartware.Radiocamp.Clients.Windows.UI.Animation;

namespace Dartware.Radiocamp.Clients.Windows.UI.AttachedProperties
{
	public sealed class AnimateSlideInFromRight : AnimateBaseProperty<AnimateSlideInFromRight>
    {
        protected override async void DoAnimation(FrameworkElement element, Boolean value, Boolean firstLoad)
        {
            if (value)
            {
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, firstLoad, firstLoad ? 0 : 0.2F, keepMargin: false);
            }
            else
            {
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.2F, keepMargin: false);
            }
        }
    }
}