using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Views;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed partial class SettingsViewModel
	{

		[Reactive]
		public SettingsSection CurrentSection { get; private set; }

		public ReactiveCommand<Unit, Unit> GoToNavigatorCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> GoToGeneralSettingsCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> GoToTraySettingsCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> GoToUISettingsCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> GoToPlaybackSettingsCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> GoToRecordSettingsCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> GoToSoundSettingsCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> GoToHotkeysSettingsCommand { get; private set; }
		public ReactiveCommand<Unit, Unit> GoToAudioDeviceSettingsCommand { get; private set; }

		private void InitializeNavigator()
		{

			this.WhenAnyValue(viewModel => viewModel.CurrentSection).Skip(1).Subscribe(currentSection =>
			{
				CloseOnEscape = currentSection == SettingsSection.Navigator;
			});

			GoToNavigatorCommand = ReactiveCommand.Create(delegate { CurrentSection = SettingsSection.Navigator; });
			GoToGeneralSettingsCommand = ReactiveCommand.Create(delegate { CurrentSection = SettingsSection.General; });
			GoToTraySettingsCommand = ReactiveCommand.Create(delegate { CurrentSection = SettingsSection.Tray; });
			GoToUISettingsCommand = ReactiveCommand.Create(delegate { CurrentSection = SettingsSection.UI; });
			GoToPlaybackSettingsCommand = ReactiveCommand.Create(delegate { CurrentSection = SettingsSection.Playback; });
			GoToRecordSettingsCommand = ReactiveCommand.Create(delegate { CurrentSection = SettingsSection.Record; });
			GoToSoundSettingsCommand = ReactiveCommand.Create(delegate { CurrentSection = SettingsSection.Sound; });
			GoToHotkeysSettingsCommand = ReactiveCommand.Create(delegate { CurrentSection = SettingsSection.Hotkeys; });
			GoToAudioDeviceSettingsCommand = ReactiveCommand.Create(delegate { CurrentSection = SettingsSection.AudioDevice; });

		}

	}
}