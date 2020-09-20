﻿using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Shared.Models;
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

		[Reactive]
		public SearchEngine SearchEngine { get; private set; }

		public ReactiveCommand<Unit, Unit> ResetCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> ChangeSearchEngineCommand { get; private set; }

		private void InitializeGeneral()
		{

			ResetCommand = ReactiveCommand.CreateFromTask(Reset);
			ChangeSearchEngineCommand = ReactiveCommand.CreateFromTask(ChangeSearchEngine);

			this.WhenAnyValue(viewModel => viewModel.RunAtWindowsStart).Skip(1).Subscribe(runAtWindowsStart => settings.RunAtWindowsStart = runAtWindowsStart);
			this.WhenAnyValue(viewModel => viewModel.ShowFavoritesAtStart).Skip(1).Subscribe(showFavoritesAtStart => settings.ShowFavoritesAtStart = showFavoritesAtStart);
			this.WhenAnyValue(viewModel => viewModel.ShowOnlyCustomAtStart).Skip(1).Subscribe(showOnlyCustomAtStart => settings.ShowOnlyCustomAtStart = showOnlyCustomAtStart);
			this.WhenAnyValue(viewModel => viewModel.StartMinimized).Skip(1).Subscribe(startMinimized => settings.StartMinimized = startMinimized);

		}

		private async Task Reset()
		{

			ConfirmArgs confirmArgs = new ConfirmArgs()
			{
				Text = LocalizationResources.Settings_ResetSettingsConfirmText,
				SecondButtonText = LocalizationResources.Settings_ResetSettingsConfirmSecondButton,
				SecondButtonType = TransparentButtonType.Danger
			};

			OverlayVisible = true;

			Boolean confirmResult = await dialogs.Confirm(confirmArgs);

			OverlayVisible = false;

			if (confirmResult)
			{
				await settings.ResetAsync();
				InitializeProperties();
			}

		}

		private async Task ChangeSearchEngine()
		{

			SelectorArgs<SearchEngine> selectorArgs = new SelectorArgs<SearchEngine>()
			{
				Current = SearchEngine,
				Width = 300,
				Height = 420,
				Callback = searchEngine => SearchEngine = searchEngine,
				Search = true
			};

			OverlayVisible = true;

			await dialogs.Selector(selectorArgs);

			OverlayVisible = false;

		}

	}
}