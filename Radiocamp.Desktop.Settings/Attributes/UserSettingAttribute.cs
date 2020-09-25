using System;

namespace Dartware.Radiocamp.Desktop.Settings
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	public sealed class UserSettingAttribute : Attribute
	{
	}
}