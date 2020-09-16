using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.ViewModels;
using Dartware.Radiocamp.Clients.Windows.Windows;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public abstract class Dialog : UserControl
	{

		private readonly DialogWindow dialogWindow;

		public ICommand CloseCommand { get; private set; }

		public Dialog()
		{
			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				dialogWindow = new DialogWindow()
				{
					Owner = Application.Current.MainWindow,
					WindowStartupLocation = WindowStartupLocation.CenterOwner
				};
				dialogWindow.ViewModel = new DialogWindowViewModel();
				CloseCommand = new RelayCommand(() => dialogWindow.Close());
			}
		}

		public Task ShowDialog<ViewModelTypeDefenition>(ViewModelTypeDefenition viewModel) where ViewModelTypeDefenition : DialogViewModel
		{

			viewModel.DialogWindow = dialogWindow;

			TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();

			Application.Current.Dispatcher.Invoke(() =>
			{
				try
				{

					dialogWindow.ViewModel.Content = this;
					DataContext = viewModel;

					dialogWindow.ShowDialog();

				}
				finally
				{
					taskCompletionSource.TrySetResult(true);
				}
			});

			Task task = taskCompletionSource.Task;

			task.ContinueWith(task =>
			{
				viewModel.Dispose();
			});

			return task;

		}

		public Task<ResultTypeDefenition> ShowDialog<ViewModelTypeDefenition, ResultTypeDefenition>(ViewModelTypeDefenition viewModel) where ViewModelTypeDefenition : DialogViewModel<ResultTypeDefenition>
		{

			viewModel.DialogWindow = dialogWindow;

			TaskCompletionSource<ResultTypeDefenition> taskCompletionSource = new TaskCompletionSource<ResultTypeDefenition>();

			Application.Current.Dispatcher.Invoke(() =>
			{
				try
				{

					dialogWindow.ViewModel.Content = this;
					DataContext = viewModel;

					dialogWindow.ShowDialog();

				}
				finally
				{
					taskCompletionSource.TrySetResult(viewModel.Result);
				}
			});

			Task<ResultTypeDefenition> task = taskCompletionSource.Task;

			task.ContinueWith(task =>
			{
				viewModel.Dispose();
			});

			return task;

		}

	}
}