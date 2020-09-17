using System;

namespace Dartware.Radiocamp.Clients.Shared
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	public sealed class UserSettingAttribute : Attribute
	{
	}
}