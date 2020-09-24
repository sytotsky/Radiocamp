using System;
using System.Globalization;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
	public sealed class ToStringConverter : BaseConverter<ToStringConverter>
	{

		public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) => value?.ToString();

		public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}
}