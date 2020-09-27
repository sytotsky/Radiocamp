using System;
using System.Reflection;
using Dartware.Radiocamp.Clients.Shared;

namespace Dartware.Radiocamp.Clients.Windows.UI.Localization
{
	internal static class ObjectExtensions
	{
		internal static String GetLocalizationResourceKey(this Object @object)
		{

			Type objectType = @object.GetType();

			LocalizationAttribute localizationAttribute = null;

			if (objectType.IsEnum)
			{

				FieldInfo field = objectType.GetField(@object.ToString());

				if (field != null)
				{
					if (Attribute.IsDefined(field, typeof(LocalizationAttribute)))
					{
						localizationAttribute = Attribute.GetCustomAttribute(field, typeof(LocalizationAttribute)) as LocalizationAttribute;
					}
				}

			}

			if (localizationAttribute == null)
			{
				return null;
			}

			return localizationAttribute.Key;

		}
	}
}