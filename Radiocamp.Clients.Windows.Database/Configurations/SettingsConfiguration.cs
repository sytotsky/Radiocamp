using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Desktop.Settings;

namespace Dartware.Radiocamp.Clients.Windows.Database.Configurations
{
	internal sealed class SettingsConfiguration : IEntityTypeConfiguration<Settings>
	{
		public  void Configure(EntityTypeBuilder<Settings> builder)
		{

			builder.ToTable("Settings");
			builder.HasKey(settings => settings.Id);

			builder.HasData(new Settings()
			{
				Id = Guid.NewGuid(),
				ExportRadiostationsAll = true,
				ExportRadiostationsSaveSoundSettings = true,
				ExportRadiostationsSaveFavoritesTags = true
			});

		}
	}
}