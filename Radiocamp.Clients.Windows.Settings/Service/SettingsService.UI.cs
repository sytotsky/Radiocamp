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
		private Boolean mainWindowTopmost;
		private Boolean mainWindowTopmostOnlyCompact;
		private Boolean hideInTaskbar;
		private Boolean hideInTaskbarOnlyCompact;

#pragma warning restore 0649

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

		[UserSetting]
		[Field(nameof(mainWindowTopmost))]
		[Event(nameof(MainWindowTopmostChanged))]
		[Default(false)]
		public Boolean MainWindowTopmost
		{
			get => mainWindowTopmost;
			set => SetValue(value);
		}

		[UserSetting]
		[Field(nameof(mainWindowTopmostOnlyCompact))]
		[Event(nameof(MainWindowTopmostOnlyCompactChanged))]
		[Default(false)]
		public Boolean MainWindowTopmostOnlyCompact
		{
			get => mainWindowTopmostOnlyCompact;
			set => SetValue(value);
		}

		[UserSetting]
		[Field(nameof(hideInTaskbar))]
		[Event(nameof(HideInTaskbarChanged))]
		[Default(false)]
		public Boolean HideInTaskbar
		{
			get => hideInTaskbar;
			set => SetValue(value);
		}

		[UserSetting]
		[Field(nameof(hideInTaskbarOnlyCompact))]
		[Event(nameof(HideInTaskbarOnlyCompactChanged))]
		[Default(false)]
		public Boolean HideInTaskbarOnlyCompact
		{
			get => hideInTaskbarOnlyCompact;
			set => SetValue(value);
		}

#pragma warning disable 0067

		public event Action<Localization> LocalizationChanged;
		public event Action<Boolean> IsNightModeChanged;
		public event Action<Boolean> MainWindowTopmostChanged;
		public event Action<Boolean> MainWindowTopmostOnlyCompactChanged;
		public event Action<Boolean> HideInTaskbarChanged;
		public event Action<Boolean> HideInTaskbarOnlyCompactChanged;

#pragma warning restore 0067

	}
}