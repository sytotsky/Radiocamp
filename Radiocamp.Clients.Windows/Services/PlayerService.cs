using System;
using Dartware.NRadio;
using Dartware.Radiocamp.Clients.Windows.Hotkeys;
using Dartware.Radiocamp.Clients.Windows.Settings;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class PlayerService : IPlayer
	{

		private readonly ISettings settings;
		private readonly IHotkeys hotkeys;
		private readonly IRadioEngine radioEngine;

		public Double Volume { get; set; }

		public PlayerService(ISettings settings, IHotkeys hotkeys)
		{
			this.settings = settings;
			this.hotkeys = hotkeys;
			radioEngine = RadioEngineFactory.Default;
			Volume = 50;
		}

	}
}