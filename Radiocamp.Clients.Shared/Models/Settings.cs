using System;
using Dartware.Radiocamp.Clients.Shared.Attributes;

namespace Dartware.Radiocamp.Clients.Shared.Models
{
	public abstract class Settings
	{
		[IgnoreProperty]
		public Guid Id { get; set; }
	}
}