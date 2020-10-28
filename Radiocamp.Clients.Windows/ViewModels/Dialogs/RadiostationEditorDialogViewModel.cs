using System;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Services;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class RadiostationEditorDialogViewModel : DialogViewModel<WindowsRadiostation>
	{

		private readonly IDialogs dialogs;

		[Reactive]
		public String Title { get; set; }

		[Reactive]
		public String StreamURL { get; set; }

		[Reactive]
		public Genre Genre { get; set; }

		[Reactive]
		public Country Country { get; set; }

		[Reactive]
		public Boolean AddToFavorites { get; set; }

		[Reactive]
		public Boolean StartPlayback { get; set; }

		[Reactive]
		public RadiostationEditorMode Mode { get; private set; }

		[Reactive]
		public Boolean CreateIsDefault { get; private set; }

		[Reactive]
		public Boolean SaveIsDefault { get; private set; }

		[Reactive]
		public Boolean SaveVisible { get; private set; }

		[Reactive]
		public Boolean CreateVisible { get; private set; }

		public ReactiveCommand<Unit, Unit> CreateCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> SaveCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> SelectGenreCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> SelectCountryCommand { get; private set; }

		public RadiostationEditorDialogViewModel(DialogArgs args) : base(args)
		{

			dialogs = Dependencies.Get<IDialogs>();
			
			if (args is RadiostationEditorArgs radiostationEditorArgs)
			{
				Mode = radiostationEditorArgs.Mode;
				CreateVisible = Mode == RadiostationEditorMode.Create;
				SaveVisible = !CreateVisible;
				CreateIsDefault = CreateVisible;
				SaveIsDefault = SaveVisible;
			}

		}

		public override void Initialize()
		{
			
			base.Initialize();

			Width = 360;

			CreateCommand = ReactiveCommand.Create(Create);
			SaveCommand = ReactiveCommand.Create(Save);
			SelectGenreCommand = ReactiveCommand.CreateFromTask(SelectGenreAsync);
			SelectCountryCommand = ReactiveCommand.CreateFromTask(SelectCountryAsync);

			disposables.Add(CreateCommand);
			disposables.Add(SaveCommand);
			disposables.Add(SelectGenreCommand);
			disposables.Add(SelectCountryCommand);

		}

		private void Create()
		{

			Result = new WindowsRadiostation()
			{
				Title = Title,
				StreamURL = StreamURL,
				Genre = Genre,
				Country = Country,
				IsFavorite = AddToFavorites,
				IsCustom = true,
				IsCurrent = StartPlayback,
				DateOfCreation = DateTime.Now
			};

			Close();

		}

		private void Save()
		{
			Close();
		}

		private async Task SelectGenreAsync()
		{
			await dialogs.Selector(new SelectorDialogArgs<Genre>(DialogWindow)
			{
				Current = Genre,
				Search = true,
				Width = 300,
				Height = 350,
				Callback = genre => Genre = genre
			});
		}

		private async Task SelectCountryAsync()
		{
			await dialogs.Selector(new SelectorDialogArgs<Country>(DialogWindow)
			{
				Current = Country,
				Search = true,
				Width = 300,
				Height = 350,
				Callback = country => Country = country
			});
		}

	}
}