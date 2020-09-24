using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows.Threading;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using DynamicData;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed partial class SettingsViewModel
	{

		private ReadOnlyObservableCollection<HotkeyItemViewModel> hotkeysItems;

		public ReadOnlyObservableCollection<HotkeyItemViewModel> HotkeysItems => hotkeysItems;

		[Reactive]
		public Boolean HotkeysIsEnabled { get; set; }

		private void InitializeHotkeys()
		{

			HotkeysIsEnabled = settings.HotkeysIsEnabled;

			hotkeys.All.Connect()
					   .NotEmpty()
					   .Transform(hotkey =>
					   {
						   return new HotkeyItemViewModel()
						   {
							   Command = hotkey.Command,
							   Key = hotkey.Key,
							   ModifierKey = hotkey.ModifierKey,
							   IsEnabled = hotkey.IsEnabled
						   };
					   })
					   .ObserveOnDispatcher(DispatcherPriority.Background)
					   .Bind(out hotkeysItems)
					   .DisposeMany()
					   .Subscribe();

			this.WhenAnyValue(viewModel => viewModel.HotkeysIsEnabled)
				.Skip(1)
				.Subscribe(hotkeysIsEnabled => settings.HotkeysIsEnabled = hotkeysIsEnabled);

		}

	}
}