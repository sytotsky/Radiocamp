using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Clients.Windows.Database.Configurations;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;

namespace Dartware.Radiocamp.Clients.Windows.Database
{
	public sealed class DatabaseContext : DbContext
	{

		public DbSet<Settings.Settings> Settings { get; set; }
		public DbSet<Hotkey> Hotkeys { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
			Database.Migrate();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new SettingsConfiguration());
			modelBuilder.ApplyConfiguration(new HotkeyConfiguration());
		}

	}
}