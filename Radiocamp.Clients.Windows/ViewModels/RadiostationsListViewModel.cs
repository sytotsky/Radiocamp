using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows.Threading;
using DynamicData;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class RadiostationsListViewModel : DynamicViewModel
	{

		private readonly IRadiostations radiostations;

		private ReadOnlyObservableCollection<RadiostationItemViewModel> radiostationsItems;

		public ReadOnlyObservableCollection<RadiostationItemViewModel> RadiostationsItems => radiostationsItems;

		public RadiostationsListViewModel(IRadiostations radiostations)
		{
			
			this.radiostations = radiostations;

			Initialize();

		}

		public override async void Initialize()
		{

			base.Initialize();

			IDisposable radiostationsSubscription = (await radiostations.ConnectAsync()).NotEmpty()
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

	}
}