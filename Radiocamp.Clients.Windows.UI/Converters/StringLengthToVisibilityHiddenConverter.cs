using System;
using System.Globalization;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.Converters
{
	public sealed class StringLengthToVisibilityHiddenConverter : BaseConverter<StringLengthToVisibilityHiddenConverter>
    {

        public override Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {

            String @string = (String) value;

            if (String.IsNullOrEmpty(@string))
            {
                @string = String.Empty;
            }

            return (@string.Length == 0) ? Visibility.Hidden : Visibility.Visible;

        }

        public override Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}