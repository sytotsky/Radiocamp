using System;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public sealed class RadiostationEditorArgs : DialogArgs
	{

		public RadiostationEditorMode Mode { get; set; }

		public RadiostationEditorArgs(BaseWindow owner, Object parameter = null) : base(owner, parameter)
		{
		}

	}
}