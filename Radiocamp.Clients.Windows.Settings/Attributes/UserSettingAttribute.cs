using System;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	public sealed class UserSettingAttribute : Attribute
	{
	}
}