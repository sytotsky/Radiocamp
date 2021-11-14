using System;
using Dartware.Radiocamp.Core.Models;
using ProtoBuf;

namespace Dartware.Radiocamp.Clients.Shared.Models
{
	[ProtoContract]
	public sealed class SerializableRadiostation
	{

		[ProtoMember(1, IsRequired = true)]
		public String Title { get; set; }
		
		[ProtoMember(2, IsRequired = true)]
		public String StreamURL { get; set; }

		[ProtoMember(4)]
		public Country Country { get; set; }

		[ProtoMember(5)]
		public Genre Genre { get; set; }

		[ProtoMember(17)]
		public Boolean IsFavorite { get; set; }
		
		[ProtoMember(18)]
		public Boolean IsCustom { get; set; }

		[ProtoMember(16)]
		public Double Volume { get; set; }

	}
}