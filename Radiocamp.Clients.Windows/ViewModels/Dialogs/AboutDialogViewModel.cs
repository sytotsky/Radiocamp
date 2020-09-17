using System;
using System.Reactive;
using System.Text;
using System.Reflection;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Shared.Services;
using Dartware.Radiocamp.Clients.Windows.Core;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class AboutDialogViewModel : DialogViewModel
	{

		[Reactive]
		public String Version { get; private set; }

		[Reactive]
		public String Copyright { get; private set; }

		public ReactiveCommand<Unit, Unit> TelegramCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> YouTubeCommand { get; private set; }

		public override void Initialize()
		{

			base.Initialize();

			Width = 360;
			Height = 300;

			IBrowser browser = Dependencies.Get<IBrowser>();

			TelegramCommand = ReactiveCommand.Create(browser.Telegram);
			YouTubeCommand = ReactiveCommand.Create(browser.YouTube);

			disposables.Add(TelegramCommand);
			disposables.Add(YouTubeCommand);

			Version = GetVersion();
			Copyright = GetCopyright();

		}

		private String GetVersion()
		{

			Assembly entryAssembly = Assembly.GetEntryAssembly();
			AssemblyName entryAssemblyName = entryAssembly.GetName();
			Version entryAssemblyVersion = entryAssemblyName.Version;
			Int32 major = entryAssemblyVersion.Major;
			Int32 minor = entryAssemblyVersion.Minor;
			Int32 build = entryAssemblyVersion.Build;
			Int32 revision = entryAssemblyVersion.Revision;

			return $"{major}.{minor}.{build}.{revision} Beta";

		}

		private String GetCopyright()
		{

			StringBuilder stringBuilder = new StringBuilder();
			Int32 launchYear = 2019;

			stringBuilder.Append($"Copyright © {launchYear}");

			Int32 currentYear = DateTime.Now.Year;

			if (currentYear > launchYear)
			{
				stringBuilder.Append($" - {currentYear}");
			}

			return stringBuilder.ToString();

		}

	}
}