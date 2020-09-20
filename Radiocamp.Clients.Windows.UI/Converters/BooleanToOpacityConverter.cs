using System;
using System.Globalization;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
    public sealed class BooleanToOpacityConverter : BaseConverter<BooleanToOpacityConverter>
    {

        public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) => ((Boolean) value) ? 1 : 0;

        public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}