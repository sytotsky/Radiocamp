using System;
using System.Globalization;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
	public sealed class NullableToBooleanConverter : BaseConverter<NullableToBooleanConverter>
	{

		public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) => value != null;

		public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}
}