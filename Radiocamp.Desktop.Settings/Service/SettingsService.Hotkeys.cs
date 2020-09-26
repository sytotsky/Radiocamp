using System;
using Microsoft.EntityFrameworkCore;

namespace Dartware.Radiocamp.Desktop.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

#pragma warning disable 0649

		private Boolean hotkeysIsEnabled;

#pragma warning restore 0649

#pragma warning disable 0067

		public event Action<Boolean> HotkeysIsEnabledChanged;

#pragma warning restore 0067

		[UserSetting]
		[Default(false)]
		[Event(nameof(HotkeysIsEnabledChanged))]
		[Field(nameof(hotkeysIsEnabled))]
		public Boolean HotkeysIsEnabled
		{
			get => hotkeysIsEnabled;
			set => SetValue(value);
		}

	}
}