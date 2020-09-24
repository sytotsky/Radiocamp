using System;
using System.Reactive.Disposables;
using Dartware.Radiocamp.Core;
using ReactiveUI;

namespace Dartware.Radiocamp.Clients.Windows.Core.MVVM
{
	public abstract class ViewModel : ReactiveObject, IDisposable, IInitializable
	{

		protected readonly CompositeDisposable disposables;

		public ViewModel()
		{
			disposables = new CompositeDisposable();
		}

		public virtual void Dispose()
		{
			disposables.Dispose();
		}

		public virtual void Initialize()
		{
		}

	}
}