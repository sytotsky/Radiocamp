using System;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public class DialogArgs
	{
		
		public BaseWindow Owner { get; }
		public Object Parameter { get; }

		public DialogArgs(BaseWindow owner, Object parameter = null)
		{
			Owner = owner;
			Parameter = parameter;
		}

	}
}