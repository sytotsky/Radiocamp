using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

		private Timer volumeTimer;

#pragma warning disable 0649

		private Int32 volumeStep;
		private Double volume;

#pragma warning restore 0649

		[Field(nameof(volume))]
		public Double Volume
		{
			get => volume;
			set
			{

				volumeTimer?.Dispose();

				volumeTimer = new Timer(state => SetValue(state, nameof(Volume)), value, 200, Timeout.Infinite);

			}
		}

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