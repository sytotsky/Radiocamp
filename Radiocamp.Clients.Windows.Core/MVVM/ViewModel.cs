﻿using System;
using System.Reactive.Disposables;
using Dartware.Radiocamp.Core;
using ReactiveUI;

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