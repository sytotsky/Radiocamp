using System;

namespace Dartware.Radiocamp.Clients.Shared
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	public sealed class DefaultAttribute : Attribute
	{
		
		public Object Value { get; }

		public DefaultAttribute(Object value)
		{
			Value = value;
		}

	}
}