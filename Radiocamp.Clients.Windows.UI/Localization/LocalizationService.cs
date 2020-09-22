using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Settings;

namespace Dartware.Radiocamp.Clients.Windows.UI.Localization
{
	public sealed class LocalizationService : ILocalization
	{

		public LocalizationService(ISettings settings)
		{
			settings.LocalizationChanged += localization => Apply(localization);
		}

		public void Apply(ApplicationLocalization localization)
		{
			Localizations.SetLocalization(localization);
		}

	}
}