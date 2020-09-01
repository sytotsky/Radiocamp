using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Shared.Database.Configurations
{
	public abstract class SettingsConfiguration<SettingsType> : IEntityTypeConfiguration<SettingsType> where SettingsType : Settings
	{
		public virtual void Configure(EntityTypeBuilder<SettingsType> builder)
		{
			builder.ToTable("Settings");
			builder.HasKey(settings => settings.Id);
		}
	}
}