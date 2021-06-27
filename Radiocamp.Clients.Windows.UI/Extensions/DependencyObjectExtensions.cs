using System;
using System.Windows;
using System.Windows.Media;
using Dartware.Radiocamp.Core;

namespace Dartware.Radiocamp.Clients.Windows.UI.Extensions
{
	public static class DependencyObjectExtensions
	{

		public static TypeDefinition GetChildOfType<TypeDefinition>(this DependencyObject dependencyObject) where TypeDefinition : DependencyObject
		{

			if (dependencyObject == null)
			{
				return null;
			}

			for (Int32 index = 0; index < VisualTreeHelper.GetChildrenCount(dependencyObject); ++index)
			{

				DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, index);
				TypeDefinition result = (child as TypeDefinition) ?? GetChildOfType<TypeDefinition>(child);

				if (result != null)
				{
					return result;
				}

			}
			
			return null;

		}

		public static TypeDefinition GetChildByName<TypeDefinition>(this DependencyObject parent, String childName) where TypeDefinition : DependencyObject
		{

			if (parent == null)
			{
				return null;
			}

			TypeDefinition foundChild = null;
			Int32 childrenCount = VisualTreeHelper.GetChildrenCount(parent);

			for (Int32 index = 0; index < childrenCount; ++index)
			{
				DependencyObject child = VisualTreeHelper.GetChild(parent, index);

				if (child is not TypeDefinition _)
				{

					foundChild = GetChildByName<TypeDefinition>(child, childName);

					if (foundChild != null)
					{
						break;
					}

				}
				else if (!childName.IsNullOrEmpty())
				{
					if (child is FrameworkElement frameworkElement && frameworkElement.Name == childName)
					{

						foundChild = (TypeDefinition)child;

						break;

					}
				}
				else
				{

					foundChild = (TypeDefinition)child;

					break;

				}
			}

			return foundChild;
		}

	}
}