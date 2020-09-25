using System;
using System.Windows;
using Dartware.Radiocamp.Core;
using Dartware.Radiocamp.Desktop.Settings;

namespace Dartware.Radiocamp.Clients.Windows.UI.Localization
{
	public sealed class LocalizationService : ILocalization
	{

		public LocalizationService(ISettings settings)
		{
			settings.LocalizationChanged += localization => Apply(localization);
		}

		public void Apply(Shared.Models.Localization localization)
		{

			String path = localization switch
			{
				Shared.Models.Localization.En => "pack://application:,,,/Radiocamp.Clients.Windows.UI;component/Localization/En.xaml",
				Shared.Models.Localization.Ru => "pack://application:,,,/Radiocamp.Clients.Windows.UI;component/Localization/Ru.xaml",
				_ => null
			};

			if (path.IsNullOrEmptyOrWhiteSpace())
			{
				return;
			}

			Application.Current.Resources.MergedDictionaries[1].Source = new Uri(path, UriKind.RelativeOrAbsolute);

		}

	}
}