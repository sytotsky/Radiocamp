using System;
using System.Windows;
using System.Windows.Controls;

namespace Dartware.Radiocamp.Clients.Windows.UI.AttachedProperties
{
    public sealed class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, Boolean>
    {
        public override void OnValueChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
        {

            base.OnValueChanged(dependency, args);

            if (!(dependency is Control control))
            {
                return;
            }

            control.Loaded += (sender, eventArgs) => control.Focus();

        }
    }
}