using System;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class SelectorItemViewModel<SelectorType> : ViewModel where SelectorType : struct, IConvertible
	{

		[Reactive]
		public SelectorType Value { get; private set; }

		[Reactive]
		public Boolean IsCurrent { get; private set; }

		[Reactive]
		public String LocalizationResourceKey { get; set; }

		[Reactive]
		public String HintLocalizationResourceKey { get; set; }

		public String SearchText { get; set; }

		public SelectorItemViewModel(SelectorType value, Boolean isCurrent, String localizationResourceKey)
		{
			Value = value;
			IsCurrent = isCurrent;
			LocalizationResourceKey = localizationResourceKey;
		}

	}
}