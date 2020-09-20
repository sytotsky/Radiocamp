using System;
using System.Windows.Data;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
	public sealed class InverseAndBooleansToBooleanConverter : IMultiValueConverter
	{

		public Object Convert(Object[] values, Type targetType, Object parameter, System.Globalization.CultureInfo culture)
		{

			if (values.LongLength > 0)
			{
				foreach (Object value in values)
				{
					if (value is Boolean && (Boolean) value)
					{
						return false;
					}
				}
			}

			return true;

		}

		public Object[] ConvertBack(Object value, Type[] targetTypes, Object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}
}