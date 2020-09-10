using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Dartware.Radiocamp.Clients.Windows.UI.Animation
{
	public static class PageAnimations
    {

		public static async Task SlideAndFadeInFromRightAsync(this Page page, Single seconds)
        {

            Storyboard storyboard = new Storyboard();
            
            storyboard.AddSlideFromRight(seconds, page.WindowWidth);
            storyboard.AddFadeIn(seconds);
            storyboard.Begin(page);
            
            page.Visibility = Visibility.Visible;
            
            await Task.Delay((Int32) (seconds * 1000));

        }

		public static async Task SlideAndFadeOutToLeftAsync(this Page page, Single seconds)
        {

            Storyboard storyboard = new Storyboard();
            
            storyboard.AddSlideToLeft(seconds, page.WindowWidth);
            storyboard.AddFadeOut(seconds);
            storyboard.Begin(page);
            
            page.Visibility = Visibility.Visible;
            
            await Task.Delay((Int32) (seconds * 1000));

        }

    }
}