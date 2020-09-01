using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Database.Configurations;

namespace Dartware.Radiocamp.Clients.Windows.Database
{
	public sealed class DatabaseContext : DbContext
	{

		public DbSet<Settings> Settings { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
			Database.Migrate();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new SettingsConfiguration());
		}

	}
}