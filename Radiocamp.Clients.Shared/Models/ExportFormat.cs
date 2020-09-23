using System;

namespace Dartware.Radiocamp.Clients.Shared.Models
{
	[Selector]
	[Localization("ImportExport_ExportFormat")]
	public enum ExportFormat : Int32
	{
		[Localization("ImportExport_BinaryFormat")]
		Binary = 0,
		[Localization("ImportExport_JSONFormat")]
		JSON = 1
	}
}