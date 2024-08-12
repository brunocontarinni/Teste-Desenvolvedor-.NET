using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Inscricoes.Shared.Utils;

public static class StringUtils
{
	public static string RemoveAccents(this string input)
	{
		if (string.IsNullOrWhiteSpace(input))
			return input;

		string normalizedString = input.Normalize(NormalizationForm.FormKD);
		StringBuilder stringBuilder = new StringBuilder();

		foreach (char c in normalizedString)
		{
			UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
			if (category != UnicodeCategory.NonSpacingMark)
				stringBuilder.Append(c);
		}

		return stringBuilder.ToString().Normalize(NormalizationForm.FormKC);
	}

	public static string NormalizeToSearch(this string input)
	{
		if (string.IsNullOrWhiteSpace(input))
			return input;

		string normalizedString = input.ToLower().Trim().RemoveAccents();

		normalizedString = Regex.Replace(normalizedString, @"[\.\-\/]", "");

		return normalizedString;
	}
}
