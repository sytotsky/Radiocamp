using System;
using System.Globalization;
using System.Windows.Media;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
	public sealed class StringRGBToColorConverter : BaseConverter<StringRGBToColorConverter>
    {

        public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) => (Color) ColorConverter.ConvertFromString($"#{value}");

		public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}