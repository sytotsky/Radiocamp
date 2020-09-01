using System;
using Microsoft.Extensions.DependencyInjection;

namespace Dartware.Radiocamp.Clients.Windows.Core
{
	public static class Dependencies
	{

		private static IServiceProvider serviceProvider;

		public static IServiceCollection Services { get; }

		static Dependencies()
		{
			Services = new ServiceCollection();
		}

		public static void Build()
		{
			serviceProvider = Services.BuildServiceProvider();
		}

		public static TypeDefenition Get<TypeDefenition>() => serviceProvider.GetService<TypeDefenition>();

	}
}