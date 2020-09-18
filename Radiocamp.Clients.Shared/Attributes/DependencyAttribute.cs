using System;

namespace Dartware.Radiocamp.Clients.Shared
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true)]
	public sealed class DependencyAttribute : Attribute
	{
	}
}