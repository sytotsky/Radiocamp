using System;
using System.Windows;
using System.Windows.Controls;

namespace Dartware.Radiocamp.Clients.Windows.UI.AttachedProperties
{
    public class PasswordBoxProperties
    {

        public static readonly DependencyProperty MonitorPasswordProperty = DependencyProperty.RegisterAttached("MonitorPassword", typeof(Boolean), typeof(PasswordBoxProperties), new PropertyMetadata(false, OnMonitorPasswordChanged));

        private static void OnMonitorPasswordChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
        {

            PasswordBox passwordBox = (dependency as PasswordBox);

            if (passwordBox == null)
            {
                return;
            }

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((Boolean) args.NewValue)
            {

                SetHasText(passwordBox);

                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;

            }

        }

        private static void PasswordBox_PasswordChanged(Object sender, RoutedEventArgs args)
        {
            SetHasText((PasswordBox) sender);
        }

        public static void SetMonitorPassword(PasswordBox element, Boolean value)
        {
            element.SetValue(MonitorPasswordProperty, value);
        }

        public static Boolean GetMonitorPassword(PasswordBox element) => (Boolean) element.GetValue(MonitorPasswordProperty);

		public static readonly DependencyProperty HasTextProperty = DependencyProperty.RegisterAttached("HasText", typeof(Boolean), typeof(PasswordBoxProperties), new PropertyMetadata(false));

        private static void SetHasText(PasswordBox element)
        {
            element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
        }

        public static Boolean GetHasText(PasswordBox element) => (Boolean) element.GetValue(HasTextProperty);

	}
}