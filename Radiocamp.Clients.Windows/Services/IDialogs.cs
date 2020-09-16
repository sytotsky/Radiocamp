using System;
using System.Threading.Tasks;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IDialogs
	{

		event Action ShowDialog;

		Task About();

	}
}