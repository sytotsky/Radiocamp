using System;

namespace Dartware.Radiocamp.Clients.Shared
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	public sealed class EventAttribute : Attribute
	{

		public String Name { get; set; }

		public EventAttribute(String name)
		{
			Name = name;
		}

	}
}