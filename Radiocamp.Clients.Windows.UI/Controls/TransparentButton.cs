using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class TransparentButton : OverButton
	{

		public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(nameof(Type), typeof(TransparentButtonType), typeof(TransparentButton), new PropertyMetadata(default(TransparentButtonType)));

		public TransparentButtonType Type
		{
			get => (TransparentButtonType) GetValue(TypeProperty);
			set => SetValue(TypeProperty, value);
		}

	}
}