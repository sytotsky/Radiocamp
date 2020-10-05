using System;
using Microsoft.EntityFrameworkCore;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

		private Int32 volumeStep;

		[UserSetting]
		[Field(nameof(volumeStep))]
		[Event(nameof(VolumeStepChanged))]
		[Default(4)]
		public Int32 VolumeStep
		{
			get => volumeStep;
			set => SetValue(value);
		}

		public event Action<Int32> VolumeStepChanged;

	}
}