using System;
using System.Collections.Generic;

namespace Dartware.Radiocamp.Core.Models
{
	public abstract class Radiostation : IEquatable<Radiostation>
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

		public Boolean Equals(Radiostation radiostation)
		{
			
			if (radiostation == null)
			{
				return false;
			}

			return Id.Equals(radiostation.Id);

		}

		public override Boolean Equals(Object other) => Equals(other as Radiostation);

		public override Int32 GetHashCode()
		{

			Int32 hashCode = -1647166910;
			
			hashCode = hashCode * -1521134295 + Id.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StreamURL);
			hashCode = hashCode * -1521134295 + DateOfCreation.GetHashCode();
			hashCode = hashCode * -1521134295 + IsFavorite.GetHashCode();
			hashCode = hashCode * -1521134295 + IsCustom.GetHashCode();
			hashCode = hashCode * -1521134295 + IsCurrent.GetHashCode();
			hashCode = hashCode * -1521134295 + Genre.GetHashCode();
			hashCode = hashCode * -1521134295 + Country.GetHashCode();
			
			return hashCode;

		}

	}
}