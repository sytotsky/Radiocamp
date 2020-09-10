using System;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class DialogDimmableOverlayViewModel : DimmableOverlayViewModel
	{

		private Int32 counter;

		public DialogDimmableOverlayViewModel()
		{
			counter = 0;
		}

		public override void Show()
		{

			++counter;

			base.Show();

		}

		public override void Hide()
		{

			--counter;

			if (counter == 0)
			{
				base.Hide();
			}

		}

	}
}