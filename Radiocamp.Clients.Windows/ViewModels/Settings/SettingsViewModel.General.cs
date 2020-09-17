using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.UI.Localization;
using Dartware.Radiocamp.Clients.Windows.UI.Controls;

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

		public ReactiveCommand<Unit, Unit> ResetCommand { get; private set; }

		private void InitializeGeneral()
		{

			ResetCommand = ReactiveCommand.CreateFromTask(Reset);

			this.WhenAnyValue(viewModel => viewModel.RunAtWindowsStart).Skip(1).Subscribe(runAtWindowsStart => settings.RunAtWindowsStart = runAtWindowsStart);
			this.WhenAnyValue(viewModel => viewModel.ShowFavoritesAtStart).Skip(1).Subscribe(showFavoritesAtStart => settings.ShowFavoritesAtStart = showFavoritesAtStart);
			this.WhenAnyValue(viewModel => viewModel.ShowOnlyCustomAtStart).Skip(1).Subscribe(showOnlyCustomAtStart => settings.ShowOnlyCustomAtStart = showOnlyCustomAtStart);
			this.WhenAnyValue(viewModel => viewModel.StartMinimized).Skip(1).Subscribe(startMinimized => settings.StartMinimized = startMinimized);

		}

		private async Task Reset()
		{

			ConfirmDialogArgs confirmDialogArgs = new ConfirmDialogArgs()
			{
				Text = LocalizationResources.Settings_ResetSettingsConfirmText,
				SecondButtonText = LocalizationResources.Settings_ResetSettingsConfirmSecondButton,
				SecondButtonType = TransparentButtonType.Danger
			};

			OverlayVisible = true;

			Boolean confirmResult = await dialogs.Confirm(confirmDialogArgs);

			OverlayVisible = false;

			if (confirmResult)
			{
				await settings.ResetAsync();
				InitializeProperties();
			}

		}

	}
}