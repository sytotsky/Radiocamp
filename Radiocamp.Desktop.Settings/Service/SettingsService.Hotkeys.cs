using System;
using Microsoft.EntityFrameworkCore;

namespace Dartware.Radiocamp.Desktop.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
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
			set => SetValue(value);
		}

	}
}