using System;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	internal sealed class FieldAttribute : Attribute
	{

		public String Name { get; }

		public FieldAttribute(String name)
		{
			Name = name;
		}

	}
}