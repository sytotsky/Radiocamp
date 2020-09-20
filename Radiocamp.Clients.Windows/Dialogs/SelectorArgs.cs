using System;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public sealed class SelectorArgs<SelectorType> where SelectorType : struct, IConvertible
	{
		public SelectorType Current { get; set; }
		public Action<SelectorType> Callback { get; set; }
		public Boolean Search { get; set; }
		public Double Width { get; set; }
		public Double Height { get; set; }
	}
}