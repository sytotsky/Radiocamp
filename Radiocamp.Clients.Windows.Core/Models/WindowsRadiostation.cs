using System;
using AutoMapper;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Core.Models
{
	[AutoMap(typeof(SerializableRadiostation), ReverseMap = true)]
	public sealed class WindowsRadiostation : Radiostation
	{
		public Double Volume { get; set; }
		public Boolean IsPinned { get; set; }
		public Boolean IsPlay { get; set; }
	}
}