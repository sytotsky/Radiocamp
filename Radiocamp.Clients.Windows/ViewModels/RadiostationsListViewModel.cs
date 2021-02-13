using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Threading;
using System.Reactive.Linq;
using DynamicData;
using DynamicData.Binding;
using DynamicData.PLinq;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Extensions;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.Settings;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class RadiostationsListViewModel : DynamicViewModel
	{

		private readonly IRadiostations radiostations;
		private readonly ISettings settings;

		private String searchQuery;
		private Boolean onlyFavorites;
		private ReadOnlyObservableCollection<RadiostationItemViewModel> items;

		public ReadOnlyObservableCollection<RadiostationItemViewModel> Items => items;

		public String SearchQuery
		{
			get => searchQuery;
			set => SetAndRaise(ref searchQuery, value);
		}
		
		public Boolean OnlyFavorites
		{
			get => onlyFavorites;
			set => SetAndRaise(ref onlyFavorites, value);
		}

		public RadiostationsListViewModel(IRadiostations radiostations, ISettings settings)
		{
			
			this.radiostations = radiostations;
			this.settings = settings;

			Initialize();

		}

		public override async void Initialize()
		{

			base.Initialize();

			OnlyFavorites = settings.ShowOnlyFavorites;

			this.WhenValueChanged(viewModel => viewModel.SearchQuery, false)
				.Subscribe(OnSearchQueryChanged);

			this.WhenValueChanged(viewModel => viewModel.OnlyFavorites)
				.Subscribe(onlyFavorites => settings.ShowOnlyFavorites = onlyFavorites);

			IObservable<Func<WindowsRadiostation, Boolean>> searchFilter = this.WhenValueChanged(viewModel => viewModel.SearchQuery)
																			   .Throttle(TimeSpan.FromMilliseconds(500))
																			   .Select(BuildSearcher);

			IObservable<Func<WindowsRadiostation, Boolean>> onlyFavoritesFilter = this.WhenValueChanged(viewModel => viewModel.OnlyFavorites)
																					  .Select(BuildOnlyFavoritesFilterPredicate);

			IDisposable radiostationsSubscription = (await radiostations.ConnectAsync()).NotEmpty()
																						.Filter(searchFilter)
																						.Filter(onlyFavoritesFilter)
																						.TransformWithInlineUpdate(radiostation => new RadiostationItemViewModel(radiostation.Id)
																						{
																							Title = radiostation.Title,
																							Genre = radiostation.Genre,
																							Country = radiostation.Country,
																							IsFavorite = radiostation.IsFavorite,
																							IsCurrent = radiostation.IsCurrent,
																							IsCustom = radiostation.IsCustom
																						}, TransformWithInlineUpdater)
																						.ObserveOnDispatcher(DispatcherPriority.Background)
																						.Bind(out items)
																						.DisposeMany()
																						.Subscribe();

			disposables.Add(radiostationsSubscription);

		}

		private void TransformWithInlineUpdater([NotNull] RadiostationItemViewModel viewModel, [NotNull] WindowsRadiostation radiostation)
		{
			viewModel.Title = radiostation.Title;
			viewModel.Genre = radiostation.Genre;
			viewModel.Country = radiostation.Country;
			viewModel.IsFavorite = radiostation.IsFavorite;
			viewModel.IsCurrent = radiostation.IsCurrent;
			viewModel.IsCustom = radiostation.IsCustom;
		}

		private void OnSearchQueryChanged(String searchQuery)
		{
			if (String.IsNullOrEmpty(searchQuery))
			{
				GC.Collect();
				GC.WaitForPendingFinalizers();
				GC.Collect();
			}
		}

		private Func<WindowsRadiostation, Boolean> BuildSearcher(String searchQuery)
		{

			if (String.IsNullOrEmpty(searchQuery))
			{
				return radiostation => true;
			}

			return radiostation =>
			{

				String preparedSearchQuery = SearchQuery.ToLower().Trim();
				String preparedTitle = radiostation.Title.ToLower();

				return preparedTitle.Contains(preparedSearchQuery);

			};

		}

		private Func<WindowsRadiostation, Boolean> BuildOnlyFavoritesFilterPredicate(Boolean onlyFavorites)
		{

			if (onlyFavorites)
			{
				return radiostation => radiostation.IsFavorite;
			}

			return radiostation => true;

		}

	}
}