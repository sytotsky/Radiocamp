using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Database;
using Dartware.Radiocamp.Clients.Windows.Services;

namespace Dartware.Radiocamp.Clients.Windows
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs args)
		{
			
			base.OnStartup(args);

			Dependencies.Services.AddDbContext<DatabaseContext>(builder =>
			{
				builder.UseSqlite("Data Source=Database.db");
			});

			Dependencies.Services.AddSingleton<ISettings, SettingsService>();

			Dependencies.Build();

		}
	}
}