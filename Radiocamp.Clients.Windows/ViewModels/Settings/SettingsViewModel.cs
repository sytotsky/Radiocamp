using Dartware.Radiocamp.Clients.Windows.Settings;
using Dartware.Radiocamp.Clients.Windows.Views;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed partial class SettingsViewModel : DialogViewModel
	{

		private readonly ISettings settings;

		public SettingsViewModel(ISettings settings)
		{
			this.settings = settings;
		}

		public override void Initialize()
		{
			base.Initialize();
			InitializeNavigator();
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