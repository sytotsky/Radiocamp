using System;

namespace Dartware.Radiocamp.Clients.Shared
{
	[AttributeUsage(AttributeTargets.All, Inherited = true)]
	public sealed class LocalizationAttribute : Attribute
	{

		public String Key { get; }

		public LocalizationAttribute(String key)
		{
			Key = key;
		}

	}
}