using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

		public Task ShowDialog<ViewModelType>(ViewModelType viewModel) where ViewModelType : DialogViewModel
		{

			viewModel.DialogWindow = dialogWindow;

			TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();

			Application.Current.Dispatcher.Invoke(() =>
			{
				try
				{

					dialogWindow.ViewModel.Content = this;
					DataContext = viewModel;

					viewModel.Initialize();
					CreateBindings(viewModel);
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

		public Task<ResultType> ShowDialog<ViewModelType, ResultType>(ViewModelType viewModel) where ViewModelType : DialogViewModel<ResultType>
		{

			viewModel.DialogWindow = dialogWindow;

			TaskCompletionSource<ResultType> taskCompletionSource = new TaskCompletionSource<ResultType>();

			Application.Current.Dispatcher.Invoke(() =>
			{
				try
				{

					dialogWindow.ViewModel.Content = this;
					DataContext = viewModel;

					viewModel.Initialize();
					CreateBindings(viewModel);
					dialogWindow.ShowDialog();

				}
				finally
				{
					taskCompletionSource.TrySetResult(viewModel.Result);
				}
			});

			Task<ResultType> task = taskCompletionSource.Task;

			task.ContinueWith(task =>
			{
				viewModel.Dispose();
			});

			return task;

		}

		private void CreateBindings(DialogViewModel viewModel)
		{

			if (viewModel == null)
			{
				return;
			}

			if (viewModel.Width > 0)
			{

				Binding widthBinding = new Binding()
				{
					Source = viewModel,
					Path = new PropertyPath(nameof(viewModel.Width)),
					Mode = BindingMode.OneWay
				};

				BindingOperations.SetBinding(this, WidthProperty, widthBinding);

			}

			if (viewModel.Height > 0)
			{

				Binding heightBinding = new Binding()
				{
					Source = viewModel,
					Path = new PropertyPath(nameof(viewModel.Height)),
					Mode = BindingMode.OneWay
				};

				BindingOperations.SetBinding(this, HeightProperty, heightBinding);

			}

			Binding minWidthBinding = new Binding()
			{
				Source = viewModel,
				Path = new PropertyPath(nameof(viewModel.MinWidth)),
				Mode = BindingMode.OneWay
			};

			BindingOperations.SetBinding(this, MinWidthProperty, minWidthBinding);

			Binding minHeightBinding = new Binding()
			{
				Source = viewModel,
				Path = new PropertyPath(nameof(viewModel.MinHeight)),
				Mode = BindingMode.OneWay
			};

			BindingOperations.SetBinding(this, MinHeightProperty, minHeightBinding);

			Binding maxWidthBinding = new Binding()
			{
				Source = viewModel,
				Path = new PropertyPath(nameof(viewModel.MaxWidth)),
				Mode = BindingMode.OneWay
			};

			BindingOperations.SetBinding(this, MaxWidthProperty, maxWidthBinding);

			Binding maxHeightBinding = new Binding()
			{
				Source = viewModel,
				Path = new PropertyPath(nameof(viewModel.MaxHeight)),
				Mode = BindingMode.OneWay
			};

			BindingOperations.SetBinding(this, MaxHeightProperty, maxHeightBinding);

			Binding paddingBinding = new Binding()
			{
				Source = viewModel,
				Path = new PropertyPath(nameof(viewModel.Padding)),
				Mode = BindingMode.OneWay
			};

			BindingOperations.SetBinding(this, PaddingProperty, paddingBinding);

		}

	}
}