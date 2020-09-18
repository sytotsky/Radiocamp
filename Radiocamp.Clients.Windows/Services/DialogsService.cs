using System;
using System.Threading.Tasks;
using Dartware.Radiocamp.Core.Extensions;
using Dartware.Radiocamp.Clients.Shared;
using Dartware.Radiocamp.Clients.Windows.Core;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.ViewModels;
using Dartware.Radiocamp.Clients.Windows.UI.Localization;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class DialogsService : IDialogs
	{

		public event Action ShowDialog;

		public Task Show<DialogType, ViewModelType>() where DialogType : Dialog, new() where ViewModelType : DialogViewModel, new()
		{

			ShowDialog?.Invoke();

			ViewModelType viewModel;
			Type viewModelType = typeof(ViewModelType);

			if (Attribute.IsDefined(viewModelType, typeof(DependencyAttribute)))
			{
				viewModel = Dependencies.Get<ViewModelType>();
			}
			else
			{
				viewModel = new ViewModelType();
			}

			return new DialogType().ShowDialog(viewModel);

		}

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

		public Task Selector<SelectorType>(SelectorType current) where SelectorType : struct, IConvertible
		{

			ShowDialog?.Invoke();

			Type selectorType = typeof(SelectorType);

			if (!selectorType.IsEnum)
			{
				throw new ArgumentException($"{nameof(SelectorType)} must be an enumerated type.");
			}

			if (!Attribute.IsDefined(selectorType, typeof(SelectorAttribute)))
			{
				throw new ArgumentException($"{nameof(SelectorType)} should be marked as Selector.");
			}

			SelectorViewModel<SelectorType> selectorViewModel = new SelectorViewModel<SelectorType>(current);

			return new Selector().ShowDialog(selectorViewModel);

		}

	}
}