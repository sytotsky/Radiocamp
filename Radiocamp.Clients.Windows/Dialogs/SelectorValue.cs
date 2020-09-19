using System;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public sealed class SelectorValue<SelectorType> where SelectorType : struct, IConvertible
	{

		public SelectorType Value { get; set; }
		public Boolean IsCurrent { get; set; }

		public SelectorValue(SelectorType value, Boolean isCurrent)
		{
			Value = value;
			IsCurrent = isCurrent;
		}

	}
}