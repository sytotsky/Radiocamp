using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Database.Configurations
{
	public sealed class RadiostationConfiguration : IEntityTypeConfiguration<WindowsRadiostation>
	{
		public void Configure(EntityTypeBuilder<WindowsRadiostation> builder)
		{
			builder.ToTable("Radiostations");
			builder.HasKey(radiostation => radiostation.Id);
			builder.Ignore(radiostation => radiostation.IsPlay);
			builder.Property(radiostation => radiostation.Created).HasDefaultValueSql("datetime('now')");
		}
	}
}