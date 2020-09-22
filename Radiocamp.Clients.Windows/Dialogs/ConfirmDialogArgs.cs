using System;
using Dartware.Radiocamp.Clients.Windows.UI.Controls;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public sealed class ConfirmDialogArgs : DialogArgs
	{

		public String Title { get; set; }
		public String Text { get; set; }
		public String FirstButtonText { get; set; }
		public String SecondButtonText { get; set; }
		public TransparentButtonType FirstButtonType { get; set; }
		public TransparentButtonType SecondButtonType { get; set; }

		public ConfirmDialogArgs(BaseWindow owner) : base(owner)
		{
			FirstButtonType = TransparentButtonType.Success;
			SecondButtonType = TransparentButtonType.Success;
		}

	}
}