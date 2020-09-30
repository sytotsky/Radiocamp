using System;
using Microsoft.EntityFrameworkCore;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

#pragma warning disable 0649

		private Boolean alwaysShowTrayIcon;
		private Boolean hideApplicationOnCloseButtonClick;
		private Boolean hideApplicationOnMinimizeButtonClick;

#pragma warning restore 0649

#pragma warning disable 0067

		public event Action<Boolean> AlwaysShowTrayIconChanged;

#pragma warning restore 0067

		[UserSetting]
		[Field(nameof(alwaysShowTrayIcon))]
		[Event(nameof(AlwaysShowTrayIconChanged))]
		[Default(true)]
		public Boolean AlwaysShowTrayIcon
		{
			get => alwaysShowTrayIcon;
			set => SetValue(value);
		}

		[UserSetting]
		[Field(nameof(hideApplicationOnCloseButtonClick))]
		[Default(true)]
		public Boolean HideApplicationOnCloseButtonClick
		{
			get => hideApplicationOnCloseButtonClick;
			set => SetValue(value);
		}

		[UserSetting]
		[Field(nameof(hideApplicationOnMinimizeButtonClick))]
		[Default(false)]
		public Boolean HideApplicationOnMinimizeButtonClick
		{
			get => hideApplicationOnMinimizeButtonClick;
			set => SetValue(value);
		}

	}
}