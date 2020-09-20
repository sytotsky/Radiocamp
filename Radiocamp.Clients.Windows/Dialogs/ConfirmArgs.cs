using System;
using System.Linq.Expressions;
using Dartware.Radiocamp.Clients.Windows.UI.Controls;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public sealed class ConfirmArgs
	{

		public String Title { get; set; }
		public String Text { get; set; }
		public String FirstButtonText { get; set; }
		public String SecondButtonText { get; set; }
		public TransparentButtonType FirstButtonType { get; set; }
		public TransparentButtonType SecondButtonType { get; set; }
		public Expression<Func<Boolean>> UpdatingFlag { get; set; }

		public ConfirmArgs()
		{
			FirstButtonType = TransparentButtonType.Success;
			SecondButtonType = TransparentButtonType.Success;
		}

	}
}