using Dartware.Radiocamp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dartware.Radiocamp.Clients.Windows.Database.Configurations
{
	public sealed class RadiostationConfiguration : IEntityTypeConfiguration<Radiostation>
	{
		public void Configure(EntityTypeBuilder<Radiostation> builder)
		{
			builder.ToTable("Radiostations");
			builder.HasKey(radiostation => radiostation.Id);
			builder.Property(radiostation => radiostation.DateOfCreation).HasDefaultValueSql("datetime('now')");
		}
	}
}