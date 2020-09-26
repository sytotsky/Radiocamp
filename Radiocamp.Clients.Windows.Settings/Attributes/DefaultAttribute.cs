using System;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	internal sealed class DefaultAttribute : Attribute
	{
		
		public Object Value { get; }

		public DefaultAttribute(Object value)
		{
			Value = value;
		}

	}
}