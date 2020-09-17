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

		private void InitializeGeneral()
		{
			this.WhenAnyValue(viewModel => viewModel.RunAtWindowsStart).Skip(1).Subscribe(runAtWindowsStart => settings.RunAtWindowsStart = runAtWindowsStart);
		}

	}
}