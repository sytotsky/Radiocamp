using System;
using System.Windows;
using System.Windows.Controls;

namespace Dartware.Radiocamp.Clients.Windows.UI.AttachedProperties
{
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, Boolean>
    {
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox) sender).SecurePassword.Length > 0);
        }
    }
}