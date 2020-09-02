using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dartware.Radiocamp.Clients.Shared.Database.Configurations;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Database.Configurations
{
	public sealed class WindowsSettingsConfiguration : SettingsConfiguration<WindowsSettings>
	{
		public override void Configure(EntityTypeBuilder<WindowsSettings> builder)
		{
			base.Configure(builder);
		}
	}
}