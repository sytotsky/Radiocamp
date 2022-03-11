using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.UI.Localization;
using Dartware.Radiocamp.Clients.Windows.UI.Controls;
using Microsoft.Win32;

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

		[Reactive]
		public SearchEngine SearchEngine { get; private set; }

		public ReactiveCommand<Unit, Unit> ResetCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> ChangeSearchEngineCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> ExportRadiostationsCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> ImportRadiostationsCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> RemoveAllRadiostationsCommand { get; private set; }

		private void InitializeGeneral()
		{

			ChangeSearchEngineCommand = ReactiveCommand.CreateFromTask(ChangeSearchEngine);
			ExportRadiostationsCommand = ReactiveCommand.CreateFromTask(ExportRadiostations);
			ImportRadiostationsCommand = ReactiveCommand.CreateFromTask(ImportRadiostations);
			RemoveAllRadiostationsCommand = ReactiveCommand.CreateFromTask(RemoveAllRadiostations);
			ResetCommand = ReactiveCommand.CreateFromTask(Reset);

			this.WhenAnyValue(viewModel => viewModel.RunAtWindowsStart)
				.Skip(1)
				.Subscribe(runAtWindowsStart => settings.RunAtWindowsStart = runAtWindowsStart);

			this.WhenAnyValue(viewModel => viewModel.ShowFavoritesAtStart)
				.Skip(1)
				.Subscribe(showFavoritesAtStart => settings.ShowFavoritesAtStart = showFavoritesAtStart);

			this.WhenAnyValue(viewModel => viewModel.ShowOnlyCustomAtStart)
				.Skip(1)
				.Subscribe(showOnlyCustomAtStart => settings.ShowOnlyCustomAtStart = showOnlyCustomAtStart);

			this.WhenAnyValue(viewModel => viewModel.StartMinimized)
				.Skip(1)
				.Subscribe(startMinimized => settings.StartMinimized = startMinimized);

			this.WhenAnyValue(viewModel => viewModel.SearchEngine)
				.Skip(1)
				.Subscribe(searchEngine => settings.SearchEngine = searchEngine);

		}

		private async Task ChangeSearchEngine()
		{
			await dialogs.Selector(new SelectorDialogArgs<SearchEngine>(DialogWindow)
			{
				Current = SearchEngine,
				Height = 420,
				Callback = searchEngine => SearchEngine = searchEngine,
			});
		}

		private async Task ExportRadiostations()
		{
			
			ExportArgs exportArgs = await dialogs.Show<ExportArgs, ExportRadiostationsDialog, ExportRadiostationsDialogViewModel>(new DialogArgs(DialogWindow));

			if (exportArgs is not null)
			{
				await radiostations.ExportAsync(exportArgs);
			}

		}

		private async Task ImportRadiostations()
		{

			OpenFileDialog openFileDialog = new OpenFileDialog()
			{
				Filter = $"{settings.ExportRadiostationsFileFormat.ToUpper()}|*.{settings.ExportRadiostationsFileFormat.ToLower()}|JSON|*.json",
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
			};
			
			if (openFileDialog.ShowDialog() == true)
			{
				await radiostations.ImportAsync(openFileDialog.FileName);
			}

		}

		private async Task RemoveAllRadiostations()
		{

			ConfirmDialogArgs confirmDialogArgs = new ConfirmDialogArgs(DialogWindow)
			{
				Text = LocalizationResources.GetLocalizationString("Settings_RemoveAllRadiostationsConfirmText"),
				SecondButtonText = LocalizationResources.GetLocalizationString("Remove_UPPERCASE"),
				SecondButtonType = TransparentButtonType.Danger
			};

			if (await dialogs.Confirm(confirmDialogArgs))
			{
				await radiostations.ClearAsync();
			}

		}

		private async Task Reset()
		{

			ConfirmDialogArgs confirmArgs = new ConfirmDialogArgs(DialogWindow)
			{
				Text = LocalizationResources.GetLocalizationString("Settings_ResetSettingsConfirmText"),
				SecondButtonText = LocalizationResources.GetLocalizationString("Reset_UPPERCASE"),
				SecondButtonType = TransparentButtonType.Danger
			};

			if (await dialogs.Confirm(confirmArgs))
			{
				await settings.ResetAsync();
				InitializeProperties();
			}

		}

	}
}