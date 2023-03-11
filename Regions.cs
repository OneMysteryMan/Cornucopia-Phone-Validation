using PhoneNumbers;

using System.Collections.Immutable;

namespace Cornucopia_Phone_Validation;

internal static class RegionMap
{
	internal static IResult Json = GetRegionMapJson();

	internal static IResult GetRegionMapJson()
	{
		var regionDict = LocaleData.Data.Keys
			.Select(code => (name: GetCountryName(code), code))
			.OrderBy(tuple => tuple.name)
			.ToDictionary(tuple => tuple.name, tuple => tuple.code);
		return Results.Json(regionDict);
	}

	private static string GetCountryName(string code)
	{
		ImmutableDictionary<string, string> langNames = LocaleData.Data[code];
		if (!langNames.TryGetValue("en", out var name))
			return "";

		if (name.Length > 0 && name[0] == '*')
			return langNames[name[1..]];

		return name;
	}
}
