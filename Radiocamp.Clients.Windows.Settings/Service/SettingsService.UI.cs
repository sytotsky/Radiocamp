using System;
using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

#pragma warning disable 0649

		private Localization localization;
		private Boolean isNightMode;

#pragma warning restore 0649

#pragma warning disable 0067

		public event Action<Localization> LocalizationChanged;
		public event Action<Boolean> IsNightModeChanged;

#pragma warning restore 0067

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