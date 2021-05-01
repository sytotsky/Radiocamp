using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Services;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class FiltersDialogViewModel : DialogViewModel
	{

		private readonly IDialogs dialogs;

		private readonly Action<Country> countryChangeCallback;
		private readonly Action<Genre> genreChangeCallback;
		private readonly Action<Boolean> isCustomOnlyChangeCallback;

		[Reactive]
		public Country Country { get; private set; }

		[Reactive]
		public Genre Genre { get; private set; }

		[Reactive]
		public Boolean IsCustomOnly { get; set; }

		public ReactiveCommand<Unit, Unit> OpenCountrySelectorCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> OpenGenreSelectorCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> ResetCommand { get; private set; }

		public FiltersDialogViewModel(DialogArgs args) : base(args)
		{

			dialogs = Dependencies.Get<IDialogs>();

			CloseOnEscape = true;
			Width = 300;

			if (args is FiltersDialogArgs filtersDialogArgs)
			{
				Country = filtersDialogArgs.Country;
				countryChangeCallback = filtersDialogArgs.CountryChangeCallback;
				Genre = filtersDialogArgs.Genre;
				genreChangeCallback = filtersDialogArgs.GenreChangeCallback;
				IsCustomOnly = filtersDialogArgs.IsCustomOnly;
				isCustomOnlyChangeCallback = filtersDialogArgs.IsCusomOnlyChangeCallback;
			}

		}

		public override void Initialize()
		{
			
			base.Initialize();

			OpenCountrySelectorCommand = ReactiveCommand.CreateFromTask(OpenCountrySelector);
			OpenGenreSelectorCommand = ReactiveCommand.CreateFromTask(OpenGenreSelector);
			ResetCommand = ReactiveCommand.Create(Reset);

			this.WhenAnyValue(viewModel => viewModel.Country)
				.Skip(1)
				.Subscribe(country => countryChangeCallback?.Invoke(country));

			this.WhenAnyValue(viewModel => viewModel.Genre)
				.Skip(1)
				.Subscribe(genre => genreChangeCallback?.Invoke(genre));

			this.WhenAnyValue(viewModel => viewModel.IsCustomOnly)
				.Skip(1)
				.Subscribe(isCustomOnly => isCustomOnlyChangeCallback?.Invoke(isCustomOnly));

		}

		private async Task OpenCountrySelector()
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

		private async Task OpenGenreSelector()
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

		private void Reset()
		{
			Country = default;
			Genre = default;
			IsCustomOnly = default;
		}

	}
}