using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Dartware.Radiocamp.Clients.Windows.UI.AttachedProperties
{
	public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, Boolean> where Parent : BaseAttachedProperty<Parent, Boolean>, new()
    {

		protected Dictionary<WeakReference, Boolean> MAlreadyLoaded = new Dictionary<WeakReference, Boolean>();

		protected Dictionary<WeakReference, Boolean> MFirstLoadValue = new Dictionary<WeakReference, Boolean>();

        public override void OnValueUpdated(DependencyObject dependency, Object value)
        {

            KeyValuePair<WeakReference, Boolean> alreadyLoadedReference;
            KeyValuePair<WeakReference, Boolean> firstLoadReference;

            if (!(dependency is FrameworkElement element))
            {
                return;
            }

            alreadyLoadedReference = MAlreadyLoaded.FirstOrDefault(pair => pair.Key.Target == dependency);
            firstLoadReference = MFirstLoadValue.FirstOrDefault(pair => pair.Key.Target == dependency);

            if ((Boolean) dependency.GetValue(ValueProperty) == (Boolean) value && alreadyLoadedReference.Key != null)
            {
                return;
            }
            
            if (alreadyLoadedReference.Key == null)
            {

                WeakReference weakReference = new WeakReference(dependency);
                RoutedEventHandler onLoaded;

                MAlreadyLoaded[weakReference] = false;
                element.Visibility = Visibility.Hidden;
                onLoaded = null;

                onLoaded = async (sender, args) =>
                {

                    element.Loaded -= onLoaded;
                    
                    await Task.Delay(5);

                    firstLoadReference = MFirstLoadValue.FirstOrDefault(pair => pair.Key.Target == dependency);

                    DoAnimation(element, firstLoadReference.Key != null ? firstLoadReference.Value : (Boolean) value, true);
                    
                    MAlreadyLoaded[weakReference] = true;

                };
                
                element.Loaded += new RoutedEventHandler(onLoaded);

            }
            else if (alreadyLoadedReference.Value == false)
            {
                MFirstLoadValue[new WeakReference(dependency)] = (Boolean) value;
            }
            else
            {
                DoAnimation(element, (Boolean) value, false);
            }

        }

		protected virtual void DoAnimation(FrameworkElement element, Boolean value, Boolean firstLoad)
        {
        }

    }
}