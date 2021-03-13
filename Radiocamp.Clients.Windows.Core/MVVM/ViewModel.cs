using System;
using System.Reactive.Disposables;
using ReactiveUI;
using Dartware.Radiocamp.Core;

namespace Dartware.Radiocamp.Clients.Windows.Core.MVVM
{
	public abstract class ViewModel : ReactiveObject, IInitializable, IDisposable
	{

		protected readonly CompositeDisposable disposables;

		public ViewModel()
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