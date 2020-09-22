using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed partial class SettingsViewModel
	{

		[Reactive]
		public Localization Localization { get; private set; }

		[Reactive]
		public Boolean IsNightMode { get; set; }

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