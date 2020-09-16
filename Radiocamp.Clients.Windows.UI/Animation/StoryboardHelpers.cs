using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Dartware.Radiocamp.Clients.Windows.UI.Animation
{
	public static class StoryboardHelpers
    {

		public static void AddSlideFromLeft(this Storyboard storyboard, Single seconds, Double offset, Single decelerationRatio = 0.9F, Boolean keepMargin = true)
        {

            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);

        }

		public static void AddSlideToLeft(this Storyboard storyboard, Single seconds, Double offset, Single decelerationRatio = 0.9F, Boolean keepMargin = true)
        {

            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = decelerationRatio
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);

        }

		public static void AddSlideFromRight(this Storyboard storyboard, Single seconds, Double offset, Single decelerationRatio = 0.9F, Boolean keepMargin = true)
        {

            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);

        }

		public static void AddSlideToRight(this Storyboard storyboard, Single seconds, Double offset, Single decelerationRatio = 0.9F, Boolean keepMargin = true)
        {

            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);

        }

		public static void AddSlideFromTop(this Storyboard storyboard, Single seconds, Double offset, Single decelerationRatio = 0.9F, Boolean keepMargin = true)
        {

            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, -offset, 0, keepMargin ? offset : 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);

        }

		public static void AddSlideToTop(this Storyboard storyboard, Single seconds, Double offset, Single decelerationRatio = 0.9F, Boolean keepMargin = true)
        {

            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(0, -offset, 0, keepMargin ? offset : 0),
                DecelerationRatio = decelerationRatio
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);

        }

		public static void AddSlideFromBottom(this Storyboard storyboard, Single seconds, Double offset, Single decelerationRatio = 0.9F, Boolean keepMargin = true)
        {

            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, keepMargin ? offset : 0, 0, -offset),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);

        }

		public static void AddSlideToBottom(this Storyboard storyboard, Single seconds, Double offset, Single decelerationRatio = 0.9F, Boolean keepMargin = true)
        {

            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(0, keepMargin ? offset : 0, 0, -offset),
                DecelerationRatio = decelerationRatio
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);

        }

		public static void AddFadeIn(this Storyboard storyboard, Single seconds, Boolean from = false)
        {

            DoubleAnimation animation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = 1,
            };

            if (from)
            {
                animation.From = 0;
            }
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);

        }

		public static void AddFadeOut(this Storyboard storyboard, Single seconds)
        {

            DoubleAnimation animation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = 0,
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);

        }

		public static void AddMarquee(this Storyboard storyboard, Single seconds, Double offset = 0, Double contentOffset = 0)
        {

            ThicknessAnimation animation = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(-contentOffset, 0, contentOffset, 0),
                RepeatBehavior = RepeatBehavior.Forever
            };
            
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);

        }

    }
}