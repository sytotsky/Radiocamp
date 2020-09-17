using System;
using System.Windows;
using Dartware.Radiocamp.Clients.Windows.Views;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public abstract class BaseSettingsDialog : Dialog
	{

		public static readonly DependencyProperty CurrentSectionProperty = DependencyProperty.Register(nameof(CurrentSection), typeof(SettingsSection), typeof(BaseSettingsDialog), new PropertyMetadata(default(SettingsSection), new PropertyChangedCallback(OnCurrentSectionChanged)));

		public SettingsSection CurrentSection
		{
			get => (SettingsSection) GetValue(CurrentSectionProperty);
			set => SetValue(CurrentSectionProperty, value);
		}

		public static readonly DependencyProperty IsNavigatorProperty = DependencyProperty.Register(nameof(IsNavigator), typeof(Boolean), typeof(BaseSettingsDialog), new PropertyMetadata(true));

		public Boolean IsNavigator
		{
			get => (Boolean) GetValue(IsNavigatorProperty);
			private set => SetValue(IsNavigatorProperty, value);
		}

		private static void OnCurrentSectionChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{

			SettingsSection newSection = (SettingsSection) args.NewValue;
			BaseSettingsDialog settingsDialog = dependency as SettingsDialog;

			if (settingsDialog != null)
			{
				settingsDialog.IsNavigator = newSection == SettingsSection.Navigator;
			}

		}

	}
}