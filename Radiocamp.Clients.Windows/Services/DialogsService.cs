using System;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class DialogsService : IDialogs
	{

		public event Action ShowDialog;

		public Task About()
		{

			ShowDialog?.Invoke();

			AboutDialogViewModel aboutDialogViewModel = new AboutDialogViewModel();

			return new AboutDialog().ShowDialog(aboutDialogViewModel);

		}

		public Task Settings()
		{

			ShowDialog?.Invoke();

			SettingsViewModel settingsViewModel = Dependencies.Get<SettingsViewModel>();

			return new SettingsDialog().ShowDialog(settingsViewModel);

		}

	}
}