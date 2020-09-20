using System;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public sealed class SelectorValue<SelectorType> where SelectorType : struct, IConvertible
	{

		public SelectorType Value { get; set; }
		public Boolean IsCurrent { get; set; }
		public String LocalizationResourceKey { get; set; }
		public String HintLocalizationResourceKey { get; set; }
		public String SearchText { get; set; }

		public SelectorValue(SelectorType value, Boolean isCurrent, String localizationResourceKey)
		{
			Value = value;
			IsCurrent = isCurrent;
			LocalizationResourceKey = localizationResourceKey;
		}

	}
}