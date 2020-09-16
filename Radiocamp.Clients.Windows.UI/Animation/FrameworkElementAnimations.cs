using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Dartware.Radiocamp.Clients.Windows.Core.Async.Tasks;

namespace Dartware.Radiocamp.Clients.Windows.UI.Animation
{
	public static class FrameworkElementAnimations
	{

		private const Int32 ANIMATION_FPS = 60;

		public static async Task SlideAndFadeInAsync(this FrameworkElement element, AnimationSlideInDirection direction, Boolean firstLoad, Single seconds = 0.3F, Boolean keepMargin = true, Int32 size = 0)
        {

            Storyboard storyboard = new Storyboard();

            storyboard.SetValue(Timeline.DesiredFrameRateProperty, ANIMATION_FPS);
            
            switch (direction)
            {
                case AnimationSlideInDirection.Left: storyboard.AddSlideFromLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin); break;
                case AnimationSlideInDirection.Right: storyboard.AddSlideFromRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin); break;
                case AnimationSlideInDirection.Top: storyboard.AddSlideFromTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin); break;
                case AnimationSlideInDirection.Bottom: storyboard.AddSlideFromBottom(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin); break;
            }
            
            storyboard.AddFadeIn(seconds);
            storyboard.Begin(element);

            if (seconds != 0 || firstLoad)
            {
                element.Visibility = Visibility.Visible;
            }
            
            await Task.Delay((Int32) (seconds * 1000));

        }

		public static async Task SlideAndFadeOutAsync(this FrameworkElement element, AnimationSlideInDirection direction, Single seconds = 0.3F, Boolean keepMargin = true, Int32 size = 0)
        {

            Storyboard storyboard = new Storyboard();

            storyboard.SetValue(Timeline.DesiredFrameRateProperty, ANIMATION_FPS);

			switch (direction)
            {
                case AnimationSlideInDirection.Left: storyboard.AddSlideToLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin); break;
                case AnimationSlideInDirection.Right: storyboard.AddSlideToRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin); break;
                case AnimationSlideInDirection.Top: storyboard.AddSlideToTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin); break;
                case AnimationSlideInDirection.Bottom: storyboard.AddSlideToBottom(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin); break;
            }
            
            storyboard.AddFadeOut(seconds);
            storyboard.Begin(element);

            if (seconds != 0)
            {
                element.Visibility = Visibility.Visible;
            }
            
            await Task.Delay((Int32) (seconds * 1000));

            if (element.Opacity == 0)
            {
                element.Visibility = Visibility.Hidden;
            }

        }

		public static async Task FadeInAsync(this FrameworkElement element, Boolean firstLoad, Single seconds = 0.3F)
        {

            Storyboard storyboard = new Storyboard();

			storyboard.SetValue(Timeline.DesiredFrameRateProperty, ANIMATION_FPS);
			storyboard.AddFadeIn(seconds);
            storyboard.Begin(element);

            if (seconds != 0 || firstLoad)
            {
                element.Visibility = Visibility.Visible;
            }
            
            await Task.Delay((Int32) (seconds * 1000));

        }

		public static async Task FadeOutAsync(this FrameworkElement element, Single seconds = 0.3F)
        {

            Storyboard storyboard = new Storyboard();

			storyboard.SetValue(Timeline.DesiredFrameRateProperty, ANIMATION_FPS);
			storyboard.AddFadeOut(seconds);
            storyboard.Begin(element);

            if (seconds != 0)
            {
                element.Visibility = Visibility.Visible;
            }
            
            await Task.Delay((Int32) (seconds * 1000));
            
            element.Visibility = Visibility.Collapsed;

        }

		public static void MarqueeAsync(this FrameworkElement element, Single seconds = 3F)
        {

            Storyboard storyboard = new Storyboard();
            Boolean unloaded = false;
            
            element.Unloaded += new RoutedEventHandler((sender, args) => unloaded = true);

            ITaskManager taskManager = new TaskManager();

            taskManager.Run(async () =>
            {
                while (element != null && !unloaded)
                {

                    Double width = 0D;
                    Double innerWidth = 0D;

                    try
                    {

                        if (element == null || unloaded)
                        {
                            break;
                        }
                        
                        width = element.ActualWidth;
                        innerWidth = ((element as Border).Child as FrameworkElement).ActualWidth;

                    }
                    catch
                    {
                        break;
                    }

                    Application.Current.Dispatcher.Invoke(() =>
                    {

                        storyboard.AddMarquee(seconds, width, innerWidth);
                        
                        storyboard.Begin(element);
                        
                        element.Visibility = Visibility.Visible;

                    });
                    
                    await Task.Delay((Int32) seconds * 1000);
                    
                    if (seconds == 0)
                    {
                        break;
                    }

                }
            });

        }
        
    }
}