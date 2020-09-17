using System;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.UI.Localization;
using Dartware.Radiocamp.Clients.Windows.ViewModels;
using Dartware.Radiocamp.Core.Extensions;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class DialogsService : IDialogs
	{

		public event Action ShowDialog;

		public Task<Boolean> Confirm(ConfirmDialogArgs args)
		{

			ShowDialog?.Invoke();

			ConfirmDialogViewModel confirmDialogViewModel = new ConfirmDialogViewModel()
			{
				Text = args.Text,
				FirstButtonType = args.FirstButtonType,
				SecondButtonType = args.SecondButtonType
			};

			if (!args.FirstButtonText.IsNullOrEmptyOrWhiteSpace())
			{
				confirmDialogViewModel.FirstButtonText = args.FirstButtonText;
			}
			else
			{
				confirmDialogViewModel.FirstButtonText = LocalizationResources.ConfirmDialog_FirstButton;
			}

			if (!args.SecondButtonText.IsNullOrEmptyOrWhiteSpace())
			{
				confirmDialogViewModel.SecondButtonText = args.SecondButtonText;
			}
			else
			{
				confirmDialogViewModel.SecondButtonText = LocalizationResources.ConfirmDialog_SecondButton;
			}

			return new ConfirmDialog().ShowDialog<ConfirmDialogViewModel, Boolean>(confirmDialogViewModel);

		}

		public Task Settings()
		{

			ShowDialog?.Invoke();

			SettingsViewModel settingsViewModel = Dependencies.Get<SettingsViewModel>();

			return new SettingsDialog().ShowDialog(settingsViewModel);

		}

		public Task About()
		{

			ShowDialog?.Invoke();

			AboutDialogViewModel aboutDialogViewModel = new AboutDialogViewModel();

			return new AboutDialog().ShowDialog(aboutDialogViewModel);

		}

	}
}