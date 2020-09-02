using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dartware.Radiocamp.Clients.Windows.Database
{
	internal sealed class DesignTimeDatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
	{
		public DatabaseContext CreateDbContext(String[] args)
		{

			DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
			String connectionString = $"Data Source={Path.Combine(Path.GetTempPath(), "DTData.db")}";

			optionsBuilder.UseSqlite(connectionString);

			return new DatabaseContext(optionsBuilder.Options);

		}
	}
}