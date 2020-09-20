using System;
using System.Reflection;

namespace Dartware.Radiocamp.Clients.Shared.Extensions
{
	public static class IConvertibleExtensions
	{

		public static String ToLocalizationResourceKey(this IConvertible convertible)
		{

			Type convertibleType = convertible.GetType();
			LocalizationAttribute localizationAttribute = null;

			if (convertibleType.IsEnum)
			{

				FieldInfo field = convertibleType.GetField(convertible.ToString());

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

		public static String ToHintLocalizationResourceKey(this IConvertible convertible)
		{

			Type convertibleType = convertible.GetType();
			HintLocalizationAttribute hintLocalizationAttribute = null;

			if (convertibleType.IsEnum)
			{

				FieldInfo field = convertibleType.GetField(convertible.ToString());

				if (field != null)
				{
					if (Attribute.IsDefined(field, typeof(HintLocalizationAttribute)))
					{
						hintLocalizationAttribute = Attribute.GetCustomAttribute(field, typeof(HintLocalizationAttribute)) as HintLocalizationAttribute;
					}
				}

			}

			if (hintLocalizationAttribute == null)
			{
				return null;
			}

			return hintLocalizationAttribute.Key;

		}

	}
}