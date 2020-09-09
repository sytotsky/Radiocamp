using System;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class WindowsSettingsService
	{

		private Boolean hotkeysIsEnabled;

		private event Action<Boolean> hotkeysIsEnabledChanged;

		public Boolean HotkeysIsEnabled
		{
			get => hotkeysIsEnabled;
			set => SetValue(hotkeysIsEnabled, nameof(hotkeysIsEnabledChanged));
		}

		public event Action<Boolean> HotkeysIsEnabledChanged
		{
			add => hotkeysIsEnabledChanged += value;
			remove => hotkeysIsEnabledChanged -= value;
		}

	}
}