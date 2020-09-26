using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dartware.Radiocamp.Clients.Windows.Database.Configurations
{
	internal sealed class SettingsConfiguration : IEntityTypeConfiguration<Settings.Settings>
	{
		public  void Configure(EntityTypeBuilder<Settings.Settings> builder)
		{

			builder.ToTable("Settings");
			builder.HasKey(settings => settings.Id);

			builder.HasData(new Settings.Settings()
			{
				Id = Guid.NewGuid(),
				ExportRadiostationsAll = true,
				ExportRadiostationsSaveSoundSettings = true,
				ExportRadiostationsSaveFavoritesTags = true
			});

		}
	}
}