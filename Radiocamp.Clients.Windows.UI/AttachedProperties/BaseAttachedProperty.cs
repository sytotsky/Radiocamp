using System;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.AttachedProperties
{
	public abstract class BaseAttachedProperty<Parent, Property> where Parent : new()
    {

		public static Parent Instance { get; private set; } = new Parent();

		public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), new UIPropertyMetadata(default(Property), new PropertyChangedCallback(OnValuePropertyChanged), new CoerceValueCallback(OnValuePropertyUpdated)));

		public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, args) => {};
		public event Action<DependencyObject, Object> ValueUpdated = (sender, value) => {};

		public static Property GetValue(DependencyObject dependency) => (Property) dependency.GetValue(ValueProperty);

		public static void SetValue(DependencyObject dependency, Property value) => dependency.SetValue(ValueProperty, value);

		public virtual void OnValueChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args) {}

		public virtual void OnValueUpdated(DependencyObject dependency, Object value) {}

		private static void OnValuePropertyChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(dependency, args);
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(dependency, args);
        }

		private static Object OnValuePropertyUpdated(DependencyObject dependency, Object value)
        {

            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(dependency, value);
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(dependency, value);

            return value;

        }

    }
}
