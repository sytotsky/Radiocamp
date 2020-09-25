using System;
using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Desktop.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
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