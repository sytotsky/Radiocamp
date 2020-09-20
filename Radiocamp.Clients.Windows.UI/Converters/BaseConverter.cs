using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
	public abstract class BaseConverter<ConverterType> : MarkupExtension, IValueConverter where ConverterType : class, new()
	{

		private static ConverterType converter = null;

		public abstract Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture);

		public abstract Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture);

		public override Object ProvideValue(IServiceProvider serviceProvider) => converter ?? (converter = new ConverterType());

	}
}