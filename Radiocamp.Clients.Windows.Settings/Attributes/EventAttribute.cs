using System;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	internal sealed class EventAttribute : Attribute
	{

		public String Name { get; set; }

		public EventAttribute(String name)
		{
			Name = name;
		}

	}
}