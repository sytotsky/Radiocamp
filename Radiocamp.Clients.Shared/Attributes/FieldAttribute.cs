using System;

namespace Dartware.Radiocamp.Clients.Shared
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	public sealed class FieldAttribute : Attribute
	{

		public String Name { get; }

		public FieldAttribute(String name)
		{
			Name = name;
		}

	}
}