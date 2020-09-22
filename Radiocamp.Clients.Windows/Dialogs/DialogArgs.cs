using Dartware.Radiocamp.Clients.Windows.UI.Windows;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public class DialogArgs
	{
		
		public BaseWindow Owner { get; }

		public DialogArgs(BaseWindow owner)
		{
			Owner = owner;
		}

	}
}