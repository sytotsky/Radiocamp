using System.Windows;
using System.Windows.Media;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public abstract class OverButton : RadiocampButton
	{

		public static readonly DependencyProperty RegularForegroundProperty = DependencyProperty.Register(nameof(RegularForeground), typeof(SolidColorBrush), typeof(OverButton), new PropertyMetadata(default(SolidColorBrush)));

		public SolidColorBrush RegularForeground
		{
			get => (SolidColorBrush) GetValue(RegularForegroundProperty);
			set => SetValue(RegularForegroundProperty, value);
		}

		public static readonly DependencyProperty OverForegroundProperty = DependencyProperty.Register(nameof(OverForeground), typeof(SolidColorBrush), typeof(OverButton), new PropertyMetadata(default(SolidColorBrush)));

		public SolidColorBrush OverForeground
		{
			get => (SolidColorBrush) GetValue(OverForegroundProperty);
			set => SetValue(OverForegroundProperty, value);
		}

		public static readonly DependencyProperty RegularBackgroundProperty = DependencyProperty.Register(nameof(RegularBackground), typeof(SolidColorBrush), typeof(OverButton), new PropertyMetadata(default(SolidColorBrush)));

		public SolidColorBrush RegularBackground
		{
			get => (SolidColorBrush) GetValue(RegularBackgroundProperty);
			set => SetValue(RegularBackgroundProperty, value);
		}

		public static readonly DependencyProperty OverBackgroundProperty = DependencyProperty.Register(nameof(OverBackground), typeof(SolidColorBrush), typeof(OverButton), new PropertyMetadata(default(SolidColorBrush)));

		public SolidColorBrush OverBackground
		{
			get => (SolidColorBrush) GetValue(OverBackgroundProperty);
			set => SetValue(OverBackgroundProperty, value);
		}

	}
}