using System;
using System.Globalization;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
    public sealed class BooleanToVisiblityHiddenConverter : BaseConverter<BooleanToVisiblityHiddenConverter>
    {

        public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (parameter == null)
			{
				return (Boolean) value ? Visibility.Visible : Visibility.Hidden;
            }
            else
			{
				return (Boolean) value ? Visibility.Hidden : Visibility.Visible;
			}
        }

        public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}