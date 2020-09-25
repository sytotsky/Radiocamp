using System;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Desktop.Settings;
using Dartware.Radiocamp.Core;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class ExportRadiostationsDialogViewModel : DialogViewModel<ExportArgs>
	{

		private readonly IDialogs dialogs;
		private readonly ISettings settings;

		[Reactive]
		public Boolean All { get; set; }

		[Reactive]
		public Boolean OnlyFavoritesOrCustom { get; set; }

		[Reactive]
		public Boolean FavoritesOnly { get; set; }

		[Reactive]
		public Boolean CustomOnly { get; set; }

		[Reactive]
		public Boolean SaveSoundSettings { get; set; }

		[Reactive]
		public Boolean SaveFavoriteTags { get; set; }

		[Reactive]
		public ExportFormat ExportFormat { get; set; }

		[Reactive]
		public String FilePath { get; set; }

		[Reactive]
		public String Path { get; set; }

		public ReactiveCommand<Unit, Unit> ExportCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> ChangeExportFormatCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> ChangeFilePathCommand { get; private set; }

		public ExportRadiostationsDialogViewModel(DialogArgs args) : base(args)
		{
			dialogs = Dependencies.Get<IDialogs>();
			settings = Dependencies.Get<ISettings>();
		}

		public override void Initialize()
		{
			
			base.Initialize();

			Width = 330;
			MaxHeight = 420;
			All = settings.ExportRadiostationsAll;
			OnlyFavoritesOrCustom = settings.ExportRadiostationsOnlyFavoritesOrCustom;
			FavoritesOnly = settings.ExportRadiostationsFavoritesOnly;
			CustomOnly = settings.ExportRadiostationsCustomOnly;
			SaveSoundSettings = settings.ExportRadiostationsSaveSoundSettings;
			SaveFavoriteTags = settings.ExportRadiostationsSaveFavoritesTags;
			ExportFormat = settings.ExportRadiostationsFormat;

			if (settings.ExportRadiostationsPath.IsNullOrEmptyOrWhiteSpace() || !Directory.Exists(settings.ExportRadiostationsPath))
			{
				settings.ExportRadiostationsPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), settings.ApplicationName);
			}

			Path = settings.ExportRadiostationsPath;
			FilePath = System.IO.Path.Combine(Path, $"{DateTime.Now:MMMM dd yyyy}.{settings.ExportRadiostationsFileFormat}");

			ExportCommand = ReactiveCommand.Create(Export);
			ChangeExportFormatCommand = ReactiveCommand.CreateFromTask(ChangeExportFormat);
			ChangeFilePathCommand = ReactiveCommand.Create(ChangeFilePath);

			disposables.Add(ExportCommand);
			disposables.Add(ChangeExportFormatCommand);
			disposables.Add(ChangeFilePathCommand);

			IDisposable allSubscription = this.WhenAnyValue(viewModel => viewModel.All)
											  .Skip(1)
											  .Subscribe(OnAllChanged);

			disposables.Add(allSubscription);

			IDisposable onlyFavoritesOrCustomSubscription = this.WhenAnyValue(viewModel => viewModel.OnlyFavoritesOrCustom)
																.Skip(1)
																.Subscribe(OnOnlyFavoritesOrCustomChanged);

			disposables.Add(onlyFavoritesOrCustomSubscription);

			IDisposable favoritesOnlySubscription = this.WhenAnyValue(viewModel => viewModel.FavoritesOnly)
														.Skip(1)
														.Subscribe(favoritesOnly => settings.ExportRadiostationsFavoritesOnly = favoritesOnly);

			disposables.Add(favoritesOnlySubscription);

			IDisposable customOnlySubscription = this.WhenAnyValue(viewModel => viewModel.CustomOnly)
													 .Skip(1)
													 .Subscribe(customOnly => settings.ExportRadiostationsCustomOnly = customOnly);

			disposables.Add(customOnlySubscription);

			IDisposable saveSoundSettingsSubscription = this.WhenAnyValue(viewModel => viewModel.SaveSoundSettings)
															.Skip(1)
															.Subscribe(saveSoundSettings => settings.ExportRadiostationsSaveSoundSettings = saveSoundSettings);

			disposables.Add(saveSoundSettingsSubscription);

			IDisposable saveFavoriteTagsSubscription = this.WhenAnyValue(viewModel => viewModel.SaveFavoriteTags)
														   .Skip(1)
														   .Subscribe(saveFavoriteTags => settings.ExportRadiostationsSaveFavoritesTags = saveFavoriteTags);

			disposables.Add(saveFavoriteTagsSubscription);

			IDisposable exportFormatSubscription = this.WhenAnyValue(viewModel => viewModel.ExportFormat)
													   .Skip(1)
													   .Subscribe(OnExportFormatChanged);

			disposables.Add(exportFormatSubscription);

			IDisposable pathSubscription = this.WhenAnyValue(viewModel => viewModel.Path)
											   .Skip(1)
											   .Subscribe(path => settings.ExportRadiostationsPath = path);

			disposables.Add(pathSubscription);

			IDisposable filePathSubscription = this.WhenAnyValue(viewModel => viewModel.FilePath)
												   .Skip(1)
												   .Subscribe(filePath => Path = System.IO.Path.GetDirectoryName(filePath));

			disposables.Add(filePathSubscription);

		}

		private void Export()
		{
			
			Result = new ExportArgs()
			{
				All = All,
				OnlyFavoritesOrCustom = OnlyFavoritesOrCustom,
				FavoritesOnly = FavoritesOnly,
				CustomOnly = CustomOnly,
				SaveSoundSettings = SaveSoundSettings,
				SaveFavoritesTags = SaveSoundSettings,
				FilePath = FilePath
			};

			Close();

		}

		private async Task ChangeExportFormat()
		{
			await dialogs.Selector(new SelectorDialogArgs<ExportFormat>(DialogWindow)
			{
				Search = false,
				Callback = exportFormat => ExportFormat = exportFormat,
				Current = ExportFormat,
			});
		}

		private void ChangeFilePath()
		{
			
			String currentFileName = System.IO.Path.GetFileName(FilePath);

			SaveFileDialog saveFileDialog = new SaveFileDialog()
			{
				DefaultExt = settings.ExportRadiostationsFileFormat,
				Filter = $"{settings.ExportRadiostationsFileFormat.ToUpper()}|*.{settings.ExportRadiostationsFileFormat.ToLower()}",
				FileName = currentFileName,
				InitialDirectory = Path
			};

			if (saveFileDialog.ShowDialog() == true)
			{
				FilePath = saveFileDialog.FileName;
			}

		}

		private void OnAllChanged(Boolean all)
		{

			settings.ExportRadiostationsAll = all;

			if (all)
			{
				OnlyFavoritesOrCustom = FavoritesOnly = CustomOnly = false;
			}

		}

		private void OnOnlyFavoritesOrCustomChanged(Boolean onlyFavoritesOrCustom)
		{

			settings.ExportRadiostationsOnlyFavoritesOrCustom = onlyFavoritesOrCustom;

			if (onlyFavoritesOrCustom)
			{
				FavoritesOnly = CustomOnly = false;
			}

		}

		private void OnExportFormatChanged(ExportFormat exportFormat)
		{
			
			settings.ExportRadiostationsFormat = exportFormat;

			String fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(FilePath);

			FilePath = System.IO.Path.Combine(Path, $"{fileNameWithoutExtension}.{settings.ExportRadiostationsFileFormat}");

		}

	}
}