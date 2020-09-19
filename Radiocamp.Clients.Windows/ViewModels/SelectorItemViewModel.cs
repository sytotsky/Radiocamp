using System;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using ReactiveUI.Fody.Helpers;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class SelectorItemViewModel<SelectorType> : ViewModel where SelectorType : struct, IConvertible
	{

		[Reactive]
		public SelectorType Value { get; private set; }

		[Reactive]
		public Boolean IsCurrent { get; private set; }

		public SelectorItemViewModel(SelectorType value, Boolean isCurrent)
		{
			Value = value;
			IsCurrent = isCurrent;
		}

	}
}