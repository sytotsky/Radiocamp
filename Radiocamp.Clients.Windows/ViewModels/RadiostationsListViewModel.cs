using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Reactive.Linq;
using DynamicData;
using DynamicData.Binding;
using DynamicData.PLinq;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Services;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class RadiostationsListViewModel : DynamicViewModel
	{

		private readonly IRadiostations radiostations;

		private String searchQuery;
		private ReadOnlyObservableCollection<RadiostationItemViewModel> radiostationsItems;

		public ReadOnlyObservableCollection<RadiostationItemViewModel> RadiostationsItems => radiostationsItems;

		public String SearchQuery
		{
			get => searchQuery;
			set => SetAndRaise(ref searchQuery, value);
		}

		public RadiostationsListViewModel(IRadiostations radiostations)
		{
			
			this.radiostations = radiostations;

			Initialize();

		}

		public override async void Initialize()
		{

			base.Initialize();

			this.WhenValueChanged(viewModel => viewModel.SearchQuery, false).Subscribe(OnSearchQueryChanged);

			IObservable<Func<WindowsRadiostation, Boolean>> searchFilter = this.WhenValueChanged(viewModel => viewModel.SearchQuery)
																			   .Throttle(TimeSpan.FromMilliseconds(500))
																			   .Select(BuildSearcher);

			IDisposable radiostationsSubscription = (await radiostations.ConnectAsync()).NotEmpty()
																						.Filter(searchFilter)
																						.Transform(radiostation => new RadiostationItemViewModel(radiostation.Id)
																						{
																							Title = radiostation.Title,
																							Genre = radiostation.Genre,
																							Country = radiostation.Country,
																							IsFavorite = radiostation.IsFavorite,
																							IsCurrent = radiostation.IsCurrent,
																							IsCustom = radiostation.IsCustom
																						})
																						.ObserveOnDispatcher(DispatcherPriority.Background)
																						.Bind(out radiostationsItems)
																						.DisposeMany()
																						.Subscribe();

			disposables.Add(radiostationsSubscription);

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

	}
}