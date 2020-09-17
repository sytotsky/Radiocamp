using System;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed partial class SettingsViewModel
	{

		[Reactive]
		public Boolean RunAtWindowsStart { get; set; }

		[Reactive]
		public Boolean ShowFavoritesAtStart { get; set; }

		[Reactive]
		public Boolean ShowOnlyCustomAtStart { get; set; }

		[Reactive]
		public Boolean StartMinimized { get; set; }

		private void InitializeGeneral()
		{
			this.WhenAnyValue(viewModel => viewModel.RunAtWindowsStart).Skip(1).Subscribe(runAtWindowsStart => settings.RunAtWindowsStart = runAtWindowsStart);
			this.WhenAnyValue(viewModel => viewModel.ShowFavoritesAtStart).Skip(1).Subscribe(showFavoritesAtStart => settings.ShowFavoritesAtStart = showFavoritesAtStart);
			this.WhenAnyValue(viewModel => viewModel.ShowOnlyCustomAtStart).Skip(1).Subscribe(showOnlyCustomAtStart => settings.ShowOnlyCustomAtStart = showOnlyCustomAtStart);
			this.WhenAnyValue(viewModel => viewModel.StartMinimized).Skip(1).Subscribe(startMinimized => settings.StartMinimized = startMinimized);
		}

	}
}