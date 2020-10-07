using System;
using Microsoft.EntityFrameworkCore;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

#pragma warning disable 0649

		private Int32 volumeStep;

#pragma warning restore 0649

		[UserSetting]
		[Field(nameof(volumeStep))]
		[Event(nameof(VolumeStepChanged))]
		[Default(4)]
		public Int32 VolumeStep
		{
			get => volumeStep;
			set => SetValue(value);
		}

#pragma warning disable 0067

		public event Action<Int32> VolumeStepChanged;

#pragma warning restore 0067

	}
}