using System;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Windows.Dialogs;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IDialogs
	{

		event Action ShowDialog;

		Task<Boolean> Confirm(ConfirmDialogArgs args);
		Task Settings();
		Task About();

	}
}