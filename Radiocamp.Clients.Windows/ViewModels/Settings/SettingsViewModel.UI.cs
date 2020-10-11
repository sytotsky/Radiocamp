using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Dialogs;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed partial class SettingsViewModel
	{

		[Reactive]
		public Localization Localization { get; private set; }

		[Reactive]
		public Boolean IsNightMode { get; set; }

		[Reactive]
		public Boolean MainWindowTopmost { get; set; }

		[Reactive]
		public Boolean MainWindowTopmostOnlyCompact { get; set; }

		[Reactive]
		public Boolean HideInTaskbar { get; set; }

		[Reactive]
		public Boolean HideInTaskbarOnlyCompact { get; set; }

		public ReactiveCommand<Unit, Unit> ChangeLocalizationCommand { get; private set; }

		private void InitializeUI()
		{

			ChangeLocalizationCommand = ReactiveCommand.CreateFromTask(ChangeLocalization);

			this.WhenAnyValue(viewModel => viewModel.Localization)
				.Skip(1)
				.Subscribe(localization => settings.Localization = localization);

			this.WhenAnyValue(viewModel => viewModel.IsNightMode)
				.Skip(1)
				.Subscribe(isNightMode => settings.IsNightMode = isNightMode);

			this.WhenAnyValue(viewModel => viewModel.MainWindowTopmost)
				.Skip(1)
				.Subscribe(mainWindowTopmost => settings.MainWindowTopmost = mainWindowTopmost);

			this.WhenAnyValue(viewModel => viewModel.MainWindowTopmostOnlyCompact)
				.Skip(1)
				.Subscribe(mainWindowTopmostOnlyCompact => settings.MainWindowTopmostOnlyCompact = mainWindowTopmostOnlyCompact);

			this.WhenAnyValue(viewModel => viewModel.HideInTaskbar)
				.Skip(1)
				.Subscribe(hideInTaskbar => settings.HideInTaskbar = hideInTaskbar);

			this.WhenAnyValue(viewModel => viewModel.HideInTaskbarOnlyCompact)
				.Skip(1)
				.Subscribe(hideInTaskbarOnlyCompact => settings.HideInTaskbarOnlyCompact = hideInTaskbarOnlyCompact);

		}

		private async Task ChangeLocalization()
		{
			await dialogs.Selector(new SelectorDialogArgs<Localization>(DialogWindow)
			{
				Current = Localization,
				Callback = localization => Localization = localization,
				Height = 222
			});
		}

	}
}