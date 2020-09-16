using System;
using System.Windows.Input;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public abstract class DimmableOverlayViewModel : ViewModel
	{

		public event Action Click;

		[Reactive]
		public Boolean Visible { get; set; }

		public virtual void Show()
		{
			Visible = true;
		}

		public virtual void Hide()
		{
			Visible = false;
		}

		public virtual void DimmableOverlay_OnMouseDown(Object sender, MouseButtonEventArgs args)
		{

			Visible = false;

			Click?.Invoke();

		}

	}
}