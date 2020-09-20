using System;
using System.Globalization;
using System.Windows.Media;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
	public sealed class StringRGBToBrushConverter : BaseConverter<StringRGBToBrushConverter>
    {

        public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) => (SolidColorBrush) (new BrushConverter().ConvertFrom($"#{value}"));

		public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}