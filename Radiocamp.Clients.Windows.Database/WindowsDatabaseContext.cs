using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Database.Configurations;

namespace Dartware.Radiocamp.Clients.Windows.Database
{
	public sealed class WindowsDatabaseContext : DbContext
	{

		public DbSet<WindowsSettings> Settings { get; set; }

		public WindowsDatabaseContext(DbContextOptions<WindowsDatabaseContext> options) : base(options)
		{
			Database.Migrate();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new WindowsSettingsConfiguration());
		}

	}
}