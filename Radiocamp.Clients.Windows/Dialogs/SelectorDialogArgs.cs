using System;
using System.Linq.Expressions;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public sealed class SelectorDialogArgs<SelectorType> : DialogArgs where SelectorType : struct, IConvertible
	{

		public SelectorType Current { get; set; }
		public Action<SelectorType> Callback { get; set; }
		public Boolean Search { get; set; }
		public Double Width { get; set; }
		public Double Height { get; set; }
		public Expression<Func<Boolean>> UpdatingFlag { get; set; }

		public SelectorDialogArgs(BaseWindow owner) : base(owner)
		{
			Search = true;
		}

	}
}