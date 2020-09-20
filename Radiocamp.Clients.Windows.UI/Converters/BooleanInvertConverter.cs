using System;
using System.Globalization;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
	public sealed class BooleanInvertConverter : BaseConverter<BooleanInvertConverter>
    {

        public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) => !((Boolean) value);

        public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) => throw new NotImplementedException();

    }
}