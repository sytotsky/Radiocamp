using System;
using Dartware.Radiocamp.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Core.Models
{
	public sealed class WindowsRadiostation : Radiostation
	{
		public Double Volume { get; set; }
		public Boolean IsPinned { get; set; }
	}
}