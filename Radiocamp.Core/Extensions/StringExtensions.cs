using System;

namespace Dartware.Radiocamp.Core.Extensions
{
	public static class StringExtensions
	{

		public static Boolean IsNullOrEmpty(this String content) => String.IsNullOrEmpty(content);

		public static Boolean IsNullOrWhiteSpace(this String content) => String.IsNullOrWhiteSpace(content);

		public static Boolean IsNullOrEmptyOrWhiteSpace(this String content) => String.IsNullOrEmpty(content) || String.IsNullOrWhiteSpace(content);

		public static String ToLowerCaseFirstChar(this String @string)
		{

			if (@string.Length > 0)
			{
				return Char.ToLower(@string[0]) + @string.Substring(1);
			}

			return String.Empty;

		}

	}
}