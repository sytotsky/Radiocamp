using System;
using System.Windows;
using System.Windows.Controls;

namespace Dartware.Radiocamp.Clients.Windows.UI.AttachedProperties
{
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, Boolean>
    {

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {

            PasswordBox passwordBox = sender as PasswordBox;

            if (passwordBox == null)
            {
                return;
            }

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((Boolean) args.NewValue)
            {

                HasTextProperty.SetValue(passwordBox);

                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;

            }

        }

        private void PasswordBox_PasswordChanged(Object sender, RoutedEventArgs args)
        {
            HasTextProperty.SetValue((PasswordBox) sender);
        }

    }
}