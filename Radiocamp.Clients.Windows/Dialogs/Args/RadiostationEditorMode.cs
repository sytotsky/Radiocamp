using System;
using Dartware.Radiocamp.Clients.Shared;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public enum RadiostationEditorMode : Int32
	{
		[Localization("RadiostationEditor_CreateTitle")]
		Create = 0,
		[Localization("RadiostationEditor_EditTitle")]
		Edit = 1
	}
}