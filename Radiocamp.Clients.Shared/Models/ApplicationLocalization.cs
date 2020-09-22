using System;

namespace Dartware.Radiocamp.Clients.Shared.Models
{
	[Selector]
	[Localization("Language")]
	public enum ApplicationLocalization : Int32
	{
		[Localization("English_EN")]
		[HintLocalization("English_EN_Code")]
		En = 0,
		[Localization("Russian_RU")]
		[HintLocalization("Russian_RU_Code")]
		Ru = 1
	}
}