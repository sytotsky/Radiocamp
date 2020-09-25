using System;

namespace Dartware.Radiocamp.Desktop.Settings
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