using System;
using System.Globalization;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
    public sealed class BooleanToVisiblityCollapsedConverter : BaseConverter<BooleanToVisiblityCollapsedConverter>
    {

        public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
	            return (Boolean) value ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
				return (Boolean) value ? Visibility.Collapsed : Visibility.Visible;
			}
        }

        public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}