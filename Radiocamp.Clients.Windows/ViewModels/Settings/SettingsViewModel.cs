using System;
using System.Reflection;
using Dartware.Radiocamp.Clients.Shared;
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

			Type settingsType = settings.GetType();
			Type thisType = GetType();
			PropertyInfo[] settingsProperties = settingsType.GetProperties();

			foreach (PropertyInfo settingsProperty in settingsProperties)
			{
				if (Attribute.IsDefined(settingsProperty, typeof(UserSettingAttribute)))
				{

					PropertyInfo thisProperty = thisType.GetProperty(settingsProperty.Name);

					if (thisProperty != null)
					{

						Object value = settingsProperty.GetValue(settings);

						thisProperty.SetValue(this, value);

					}

				}
			}

			InitializeNavigator();
			InitializeGeneral();

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