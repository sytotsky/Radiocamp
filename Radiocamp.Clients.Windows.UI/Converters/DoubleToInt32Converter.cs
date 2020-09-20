using System;
using System.Globalization;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
	public sealed class DoubleToInt32Converter : BaseConverter<DoubleToInt32Converter>
	{

		public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			if (value is Double)
			{
				return (Int32) ((Double) value);
			}
			else
			{
				throw new InvalidCastException();
			}
		}

		public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}
}