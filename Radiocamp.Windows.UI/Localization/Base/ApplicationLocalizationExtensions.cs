using System;
using Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Windows.UI.Localization
{
	public static class ApplicationLocalizationExtensions
	{

		public static String ToLocalizeString(this ApplicationLocalization localization)
		{
			return localization switch
			{
				ApplicationLocalization.En => "en-US",
				ApplicationLocalization.Ru => "ru-RU",
				_ => null,
			};
		}

		public static Localization ToLocalization(this ApplicationLocalization localization)
		{
			return localization switch
			{
				ApplicationLocalization.En => new Localization("En", "pack://application:,,,/Radiocamp.Windows.UI;component/Localization/En.xaml"),
				ApplicationLocalization.Ru => new Localization("Ru", "pack://application:,,,/Radiocamp.Windows.UI;component/Localization/Ru.xaml"),
				_ => null,
			};
		}

	}
}