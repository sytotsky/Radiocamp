using System;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class SelectorViewModel<SelectorType> : DialogViewModel where SelectorType : struct, IConvertible
	{

		private readonly Action<SelectorType> changeCallback;
		
		private SelectorType current;

		public SelectorViewModel(SelectorType current, Action<SelectorType> changeCallback)
		{
			this.current = current;
			this.changeCallback = changeCallback;
		}

		public override void Initialize()
		{
			base.Initialize();
		}

	}
}