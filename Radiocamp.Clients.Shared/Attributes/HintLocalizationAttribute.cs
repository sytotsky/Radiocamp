using System;

namespace Dartware.Radiocamp.Clients.Shared
{
	[AttributeUsage(AttributeTargets.All, Inherited = true)]
	public sealed class HintLocalizationAttribute : Attribute
	{

		public String Key { get; }

		public HintLocalizationAttribute(String key)
		{
			Key = key;
		}

	}
}