using System;
using Dartware.Radiocamp.Clients.Shared;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class WindowsSettingsService
	{

		private Localization localization;
		private Boolean isNightMode;

		public event Action<Localization> LocalizationChanged;
		public event Action<Boolean> IsNightModeChanged;

		[UserSetting]
		[Field(nameof(localization))]
		[Event(nameof(LocalizationChanged))]
		[Default(Localization.En)]
		public Localization Localization
		{
			get => localization;
			set => SetValue(value);
		}

		[UserSetting]
		[Field(nameof(isNightMode))]
		[Event(nameof(IsNightModeChanged))]
		[Default(false)]
		public Boolean IsNightMode
		{
			get => isNightMode;
			set => SetValue(value);
		}

	}
}