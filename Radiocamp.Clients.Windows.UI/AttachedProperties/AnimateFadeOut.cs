using System;
using System.Windows;
using Dartware.Radiocamp.Clients.Windows.UI.Animation;

namespace Dartware.Radiocamp.Clients.Windows.UI.AttachedProperties
{
	public sealed class AnimateFadeOut : AnimateBaseProperty<AnimateFadeOut>
    {
        protected override async void DoAnimation(FrameworkElement element, Boolean value, Boolean firstLoad)
        {
			if (value)
            {
                await element.FadeOutAsync(firstLoad ? 0 : 0.2F);
            }
            else
            {
                await element.FadeInAsync(firstLoad, firstLoad ? 0 : 0.2F);
            }
        }
    }
}