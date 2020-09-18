using System;
using Dartware.Radiocamp.Clients.Shared;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class WindowsSettingsService
	{

		private Boolean hotkeysIsEnabled;

		private event Action<Boolean> hotkeysIsEnabledChanged;

		[UserSetting]
		[Default(false)]
		[Event(nameof(hotkeysIsEnabledChanged))]
		public Boolean HotkeysIsEnabled
		{
			get => hotkeysIsEnabled;
			set => SetValue(hotkeysIsEnabled);
		}

		public event Action<Boolean> HotkeysIsEnabledChanged
		{
			add => hotkeysIsEnabledChanged += value;
			remove => hotkeysIsEnabledChanged -= value;
		}

	}
}