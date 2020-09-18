using System;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class SelectorViewModel<SelectorType> : DialogViewModel where SelectorType : struct, IConvertible
	{

		private readonly SelectorType current;

		public SelectorViewModel(SelectorType current)
		{
			this.current = current;
		}

		public override void Initialize()
		{
			base.Initialize();
		}

	}
}