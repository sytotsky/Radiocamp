using System;
using Dartware.Radiocamp.Clients.Windows.Settings;
using Dartware.Radiocamp.Clients.Windows.Views;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed partial class SettingsViewModel : DialogViewModel
	{

		private readonly ISettings settings;

		private Boolean isInitialized;

		public SettingsViewModel(ISettings settings)
		{
			this.settings = settings;
		}

		public override void Initialize()
		{

			base.Initialize();

			if (isInitialized)
			{
				return;
			}

			InitializeNavigator();

			isInitialized = true;

		}

		public override void Dispose()
		{
			CurrentSection = SettingsSection.Navigator;
		}

		protected override void OnEscape()
		{
			
			base.OnEscape();
			
			CurrentSection = SettingsSection.Navigator;

		}

	}
}