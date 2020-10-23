using System;
using System.Reactive.Disposables;
using DynamicData.Binding;
using Dartware.Radiocamp.Core;

namespace Dartware.Radiocamp.Clients.Windows.Core.MVVM
{
	public abstract class DynamicViewModel : AbstractNotifyPropertyChanged, IInitializable, IDisposable
	{

		protected readonly CompositeDisposable disposables;

		public DynamicViewModel()
		{
			disposables = new CompositeDisposable();
		}

		public virtual void Initialize()
		{
		}

		public virtual void Dispose()
		{
			disposables.Dispose();
		}

	}
}