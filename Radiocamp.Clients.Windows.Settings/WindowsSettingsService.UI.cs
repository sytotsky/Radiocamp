using System;
using Dartware.Radiocamp.Clients.Shared;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class WindowsSettingsService
	{

		private ApplicationLocalization localization;
		private Boolean isNightMode;

		public event Action<ApplicationLocalization> LocalizationChanged;
		public event Action<Boolean> IsNightModeChanged;

		[UserSetting]
		[Field(nameof(localization))]
		[Event(nameof(LocalizationChanged))]
		[Default(ApplicationLocalization.En)]
		public ApplicationLocalization Localization
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