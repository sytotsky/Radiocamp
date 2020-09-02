using System;

namespace Dartware.Radiocamp.Clients.Shared.Attributes
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	public sealed class IgnorePropertyAttribute : Attribute
	{
	}
}