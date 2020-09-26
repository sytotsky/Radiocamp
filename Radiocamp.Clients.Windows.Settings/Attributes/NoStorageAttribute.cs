using System;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	internal sealed class NoStorageAttribute : Attribute
	{
	}
}