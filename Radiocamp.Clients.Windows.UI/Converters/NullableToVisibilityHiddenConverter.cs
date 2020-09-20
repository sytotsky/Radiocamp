using System;
using System.Globalization;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
	public sealed class NullableToVisibilityHiddenConverter : BaseConverter<NullableToBooleanConverter>
	{

		public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) => value == null ? Visibility.Hidden : Visibility.Visible;

		public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}
}