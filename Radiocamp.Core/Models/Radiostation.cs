using System;

namespace Dartware.Radiocamp.Core.Models
{
	public sealed class Radiostation
	{
		public Guid Id { get; set; }
		public String Title { get; set; }
		public String StreamURL { get; set; }
		public DateTime DateOfCreation { get; set; }
		public Boolean IsFavorite { get; set; }
		public Boolean IsCustom { get; set; }
		public Boolean IsCurrent { get; set; }
		public Genre Genre { get; set; }
		public Country Country { get; set; }
	}
}