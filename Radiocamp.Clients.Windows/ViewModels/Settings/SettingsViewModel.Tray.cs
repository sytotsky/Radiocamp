using System;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed partial class SettingsViewModel
	{

		[Reactive]
		public Boolean AlwaysShowTrayIcon { get; set; }

		[Reactive]
		public Boolean HideApplicationOnCloseButtonClick { get; set; }

		[Reactive]
		public Boolean HideApplicationOnMinimizeButtonClick { get; set; }

		private void InitializeTray()
		{

			this.WhenAnyValue(viewModel => viewModel.AlwaysShowTrayIcon)
				.Skip(1)
				.Subscribe(alwaysShowTrayIcon => settings.AlwaysShowTrayIcon = alwaysShowTrayIcon);

			this.WhenAnyValue(viewModel => viewModel.HideApplicationOnCloseButtonClick)
				.Skip(1)
				.Subscribe(hideApplicationOnCloseButtonClick => settings.HideApplicationOnCloseButtonClick = hideApplicationOnCloseButtonClick);

			this.WhenAnyValue(viewModel => viewModel.HideApplicationOnMinimizeButtonClick)
				.Skip(1)
				.Subscribe(hideApplicationOnMinimizeButtonClick => settings.HideApplicationOnMinimizeButtonClick = hideApplicationOnMinimizeButtonClick);

		}

	}
}