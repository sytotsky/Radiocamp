using System;
using System.Windows;

namespace Dartware.Radiocamp.Windows.UI.Localization
{
	public static class LocalizationResources
	{

		#region Shared

		public static String Unknown => GetLocalizationString(nameof(Unknown));
		public static String ShowList => GetLocalizationString(nameof(ShowList));
		public static String HideList => GetLocalizationString(nameof(HideList));

		#endregion

		#region Errors

		public static String Errors_InvalidURL => GetLocalizationString(nameof(Errors_InvalidURL));
		public static String Errors_NoInternetConnection => GetLocalizationString(nameof(Errors_NoInternetConnection));
		public static String Errors_ConnectionError => GetLocalizationString(nameof(Errors_ConnectionError));

		#endregion

		#region Dialog

		public static String Dialog_Cancel => GetLocalizationString(nameof(Dialog_Cancel));

		#endregion

		#region Confirm Dialog

		public static String ConfirmDialog_FirstButton => GetLocalizationString(nameof(ConfirmDialog_FirstButton));
		public static String ConfirmDialog_SecondButton => GetLocalizationString(nameof(ConfirmDialog_SecondButton));

		#endregion

		#region Radiostation Editor

		public static String RadiostationEditor_CreateTitle => GetLocalizationString(nameof(RadiostationEditor_CreateTitle));
		public static String RadiostationEditor_Create => GetLocalizationString(nameof(RadiostationEditor_Create));
		public static String RadiostationEditor_EditTitle => GetLocalizationString(nameof(RadiostationEditor_EditTitle));
		public static String RadiostationEditor_Save => GetLocalizationString(nameof(RadiostationEditor_Save));

		#endregion

		#region Settings

		public static String Settings_ClearPlaybackHistoryConfirmText => GetLocalizationString(nameof(Settings_ClearPlaybackHistoryConfirmText));
		public static String Settings_ClearPlaybackHistoryConfirmSecondButton => GetLocalizationString(nameof(Settings_ClearPlaybackHistoryConfirmSecondButton));
		public static String Settings_ResetSettingsConfirmText => GetLocalizationString(nameof(Settings_ResetSettingsConfirmText));
		public static String Settings_ResetSettingsConfirmSecondButton => GetLocalizationString(nameof(Settings_ResetSettingsConfirmSecondButton));
		public static String Settings_RemoveAllRadiostationsConfirmText => GetLocalizationString(nameof(Settings_RemoveAllRadiostationsConfirmText));
		public static String Settings_RemoveAllRadiostationsConfirmSecondButton => GetLocalizationString(nameof(Settings_RemoveAllRadiostationsConfirmSecondButton));

		#endregion

		#region Validation

		public static String Validation_MaxRule_ErrorMessage => GetLocalizationString(nameof(Validation_MaxRule_ErrorMessage));
		public static String Validation_URLRule_ErrorMessage => GetLocalizationString(nameof(Validation_URLRule_ErrorMessage));

		#endregion

		#region Audio Device Selector

		public static String AudioDeviceSelector_DevicesNotFound => GetLocalizationString(nameof(AudioDeviceSelector_DevicesNotFound));

		#endregion

		#region Equalizer Presets

		public static String EqualizerPresets_Default => GetLocalizationString(nameof(EqualizerPresets_Default));
		public static String EqualizerPresets_AmplifyBass => GetLocalizationString(nameof(EqualizerPresets_AmplifyBass));
		public static String EqualizerPresets_FullBassAndTreble => GetLocalizationString(nameof(EqualizerPresets_FullBassAndTreble));
		public static String EqualizerPresets_AmplifyTreble => GetLocalizationString(nameof(EqualizerPresets_AmplifyTreble));
		public static String EqualizerPresets_LaptopSpeakers => GetLocalizationString(nameof(EqualizerPresets_LaptopSpeakers));
		public static String EqualizerPresets_LargeHall => GetLocalizationString(nameof(EqualizerPresets_LargeHall));
		public static String EqualizerPresets_Live => GetLocalizationString(nameof(EqualizerPresets_Live));
		public static String EqualizerPresets_Party => GetLocalizationString(nameof(EqualizerPresets_Party));
		public static String EqualizerPresets_Current => GetLocalizationString(nameof(EqualizerPresets_Current));

		#endregion

		public static String GetLocalizationString(String resourceKey) => (String) Application.Current.FindResource(resourceKey);

	}
}