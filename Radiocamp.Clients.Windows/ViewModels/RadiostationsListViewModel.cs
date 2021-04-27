using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Threading;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using DynamicData;
using DynamicData.Binding;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.Extensions;
using Dartware.Radiocamp.Clients.Windows.Services;
using Dartware.Radiocamp.Clients.Windows.Settings;
using Dartware.Radiocamp.Clients.Windows.UI.Resources.Icons;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class RadiostationsListViewModel : DynamicViewModel
	{

		private readonly IRadiostations radiostations;
		private readonly ISettings settings;
		private readonly IDialogs dialogs;
		private readonly IMainWindow mainWindow;

		private ReadOnlyObservableCollection<RadiostationItemViewModel> items;
		private String searchQuery;
		private Boolean onlyFavorites;
		private SortingType sortingType;
		private SortExpressionComparer<RadiostationItemViewModel> sortingComparer;
		private String sortingButtonIcon;

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

		public SortingType SortingType
		{
			get => sortingType;
			set => SetAndRaise(ref sortingType, value);
		}

		public SortExpressionComparer<RadiostationItemViewModel> SortingComparer
		{
			get => sortingComparer;
			private set => SetAndRaise(ref sortingComparer, value);
		}

		public String SortingButtonIcon
		{
			get => sortingButtonIcon;
			private set => SetAndRaise(ref sortingButtonIcon, value);
		}

		public ReactiveCommand<Unit, Unit> ShowSortingSelectorCommand { get; private set; }

		public RadiostationsListViewModel(IRadiostations radiostations, ISettings settings, IDialogs dialogs, IMainWindow mainWindow)
		{
			
			this.radiostations = radiostations;
			this.settings = settings;
			this.dialogs = dialogs;
			this.mainWindow = mainWindow;

			Initialize();

		}

		public override async void Initialize()
		{

			base.Initialize();

			OnlyFavorites = settings.ShowOnlyFavorites;
			SortingType = settings.SortingType;

			ShowSortingSelectorCommand = ReactiveCommand.CreateFromTask(ShowSortingSelectorAsync);

			this.WhenValueChanged(viewModel => viewModel.SearchQuery, false)
				.Subscribe(OnSearchQueryChanged);

			this.WhenValueChanged(viewModel => viewModel.OnlyFavorites)
				.Subscribe(onlyFavorites => settings.ShowOnlyFavorites = onlyFavorites);

			this.WhenValueChanged(viewModel => viewModel.SortingType)
				.Subscribe(OnSortingTypeChanged);

			IObservable<Func<WindowsRadiostation, Boolean>> searchFilter = this.WhenValueChanged(viewModel => viewModel.SearchQuery)
																			   .Throttle(TimeSpan.FromMilliseconds(500))
																			   .Select(BuildSearcher);

			IObservable<Func<WindowsRadiostation, Boolean>> onlyFavoritesFilter = this.WhenValueChanged(viewModel => viewModel.OnlyFavorites)
																					  .Select(BuildOnlyFavoritesFilterPredicate);

			IObservable<IComparer<RadiostationItemViewModel>> sorting = this.WhenPropertyChanged(viewModel => viewModel.SortingComparer)
																			.Select(propertyValue => propertyValue.Value);

			IDisposable radiostationsSubscription = (await radiostations.ConnectAsync()).NotEmpty()
																						.Filter(searchFilter)
																						.Filter(onlyFavoritesFilter)
																						.TransformWithInlineUpdate(radiostation => new RadiostationItemViewModel(radiostation.Id)
																						{
																							Title = radiostation.Title,
																							StreamURL = radiostation.StreamURL,
																							Genre = radiostation.Genre,
																							Country = radiostation.Country,
																							IsFavorite = radiostation.IsFavorite,
																							IsCurrent = radiostation.IsCurrent,
																							IsCustom = radiostation.IsCustom,
																							IsPinned = radiostation.IsPinned,
																							IsPlay = radiostation.IsPlay
																						}, TransformWithInlineUpdater)
																						.Sort(sorting)
																						.ObserveOnDispatcher(DispatcherPriority.Background)
																						.Bind(out items)
																						.DisposeMany()
																						.Subscribe();

			disposables.Add(radiostationsSubscription);

		}

		private void OnSortingTypeChanged(SortingType sortingType)
		{

			SortingComparer = sortingType switch
			{
				SortingType.NameAscending => SortExpressionComparer<RadiostationItemViewModel>.Descending(item => item.IsPinned).ThenByAscending(item => item.Title),
				SortingType.NameDescending => SortExpressionComparer<RadiostationItemViewModel>.Descending(item => item.IsPinned).ThenByDescending(item => item.Title),
				SortingType.FavoritesFirst => SortExpressionComparer<RadiostationItemViewModel>.Descending(item => item.IsPinned).ThenByDescending(item => item.IsFavorite),
				// SortingType.PopularFirst => SortExpressionComparer<RadiostationItemViewModel>.Descending(item => item.IsPinned).ThenByDescending(item => item.ListenTime),
				// SortingType.DateAddedAscending => SortExpressionComparer<RadiostationItemViewModel>.Descending(item => item.IsPinned).ThenByAscending(item => item.DateOfCreation),
				// SortingType.DateAddedDescending => SortExpressionComparer<RadiostationItemViewModel>.Descending(item => item.IsPinned).ThenByDescending(item => item.DateOfCreation),
				// SortingType.PlaybackOrder => SortExpressionComparer<RadiostationItemViewModel>.Descending(item => item.IsPinned).ThenByDescending(item => item.LastPlayTime),
				SortingType.CustomFirst => SortExpressionComparer<RadiostationItemViewModel>.Descending(item => item.IsPinned).ThenByDescending(item => item.IsCustom),
				_ => SortExpressionComparer<RadiostationItemViewModel>.Descending(item => item.IsPinned)
			};

			SortingButtonIcon = sortingType switch
			{
				SortingType.NameAscending or SortingType.PlaybackOrder or SortingType.DateAddedAscending => IconsResources.SortingAscendingIcon,
				SortingType.NameDescending or SortingType.FavoritesFirst or SortingType.PopularFirst or SortingType.CustomFirst or SortingType.DateAddedDescending => IconsResources.SortingDescendingIcon,
				_ => IconsResources.SortingIcon
			};

			settings.SortingType = sortingType;

			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();

		}

		private void TransformWithInlineUpdater([NotNull] RadiostationItemViewModel viewModel, [NotNull] WindowsRadiostation radiostation)
		{
			viewModel.Title = radiostation.Title;
			viewModel.StreamURL = radiostation.StreamURL;
			viewModel.Genre = radiostation.Genre;
			viewModel.Country = radiostation.Country;
			viewModel.IsFavorite = radiostation.IsFavorite;
			viewModel.IsCurrent = radiostation.IsCurrent;
			viewModel.IsCustom = radiostation.IsCustom;
			viewModel.IsPinned = radiostation.IsPinned;
			viewModel.IsPlay = radiostation.IsPlay;
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
				return _ => true;
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

			return _ => true;

		}

		private async Task ShowSortingSelectorAsync()
		{
			await dialogs.Selector(new SelectorDialogArgs<SortingType>(mainWindow.Window)
			{
				Callback = sortingType => SortingType = sortingType,
				Current = SortingType,
				Search = true,
				Height = 382,
				Width = 350
			});
		}

	}
}