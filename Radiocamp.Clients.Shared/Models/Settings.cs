using System;

namespace Dartware.Radiocamp.Clients.Shared.Models
{
	public abstract class Settings
	{
		[Ignore]
		public Guid Id { get; set; }
	}
}