using System;
using System.Threading.Tasks;
using Dartware.Radiocamp.Core;
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

		public Task Show<DialogType, ViewModelType>(DialogArgs args) where DialogType : Dialog, new() where ViewModelType : DialogViewModel
		{

			ViewModelType viewModel;
			Type viewModelType = typeof(ViewModelType);

			if (Attribute.IsDefined(viewModelType, typeof(DependencyAttribute)))
			{
				viewModel = Dependencies.Get<ViewModelType>();
			}
			else
			{
				viewModel = Activator.CreateInstance(typeof(ViewModelType), new Object[]
				{
					args
				}) as ViewModelType;
			}

			return Show<DialogType>(viewModel);

		}

		public Task<Boolean> Confirm(ConfirmDialogArgs args)
		{

			ConfirmDialogViewModel confirmDialogViewModel = new ConfirmDialogViewModel(args)
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

			return Show<ConfirmDialog, Boolean>(confirmDialogViewModel);

		}

		public Task Selector<SelectorType>(SelectorDialogArgs<SelectorType> args = null) where SelectorType : struct, IConvertible
		{

			Type selectorType = typeof(SelectorType);

			if (!selectorType.IsEnum)
			{
				throw new ArgumentException($"{nameof(SelectorType)} must be an enumerated type.");
			}

			if (!Attribute.IsDefined(selectorType, typeof(SelectorAttribute)))
			{
				throw new ArgumentException($"{nameof(SelectorType)} should be marked as Selector.");
			}

			SelectorDialogViewModel<SelectorType> selectorDialogViewModel = new SelectorDialogViewModel<SelectorType>(args);

			return Show<SelectorDialog>(selectorDialogViewModel);

		}

		private Task Show<DialogType>(IDialogViewModel viewModel) where DialogType : Dialog, new()
		{

			ShowDialog?.Invoke();

			return new DialogType().ShowDialog(viewModel);

		}

		private Task<ResultType> Show<DialogType, ResultType>(IDialogViewModel<ResultType> viewModel) where DialogType : Dialog, new()
		{

			ShowDialog?.Invoke();

			return new DialogType().ShowDialog<IDialogViewModel<ResultType>, ResultType>(viewModel);


		}

	}
}