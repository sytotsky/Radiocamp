using System;
using DynamicData.Binding;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{

	public abstract class SelectorDialogValue : AbstractNotifyPropertyChanged
	{
		public abstract void Select();
	}

	public sealed class SelectorDialogValue<SelectorType> : SelectorDialogValue where SelectorType : struct, IConvertible
	{

		private SelectorType value;
		private Boolean isCurrent;
		private String localizationResourceKey;
		private String hintLocalizationResourceKey;

		public SelectorType Value
		{
			get => value;
			set => SetAndRaise(ref this.value, value);
		}

		public Boolean IsCurrent
		{
			get => isCurrent;
			set => SetAndRaise(ref isCurrent, value);
		}

		public String LocalizationResourceKey
		{
			get => localizationResourceKey;
			set => SetAndRaise(ref localizationResourceKey, value);
		}

		public String HintLocalizationResourceKey
		{
			get => hintLocalizationResourceKey;
			set => SetAndRaise(ref hintLocalizationResourceKey, value);
		}
		
		public String SearchText { get; set; }
		public Action<SelectorDialogValue<SelectorType>> SelectCallback { get; set; }

		public override void Select()
		{
			SelectCallback?.Invoke(this);
		}

	}

}