using System;

namespace Dartware.Radiocamp.Desktop.Settings
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	internal sealed class NoStorageAttribute : Attribute
	{
	}
}