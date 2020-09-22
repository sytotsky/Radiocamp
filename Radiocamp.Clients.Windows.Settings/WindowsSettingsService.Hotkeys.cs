using System;
using Dartware.Radiocamp.Clients.Shared;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class WindowsSettingsService
	{

		private Boolean hotkeysIsEnabled;

		public event Action<Boolean> HotkeysIsEnabledChanged;

		[UserSetting]
		[Default(false)]
		[Event(nameof(HotkeysIsEnabledChanged))]
		[Field(nameof(hotkeysIsEnabled))]
		public Boolean HotkeysIsEnabled
		{
			get => hotkeysIsEnabled;
			set => SetValue(hotkeysIsEnabled);
		}

	}
}