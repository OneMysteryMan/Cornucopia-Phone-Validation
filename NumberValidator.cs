using PhoneNumbers;

namespace Cornucopia_Phone_Validation;

public class NumberValidator
{
	internal static IResult Parse(string? phoneNumber, string? region)
	{
		if (phoneNumber is null) return Results.BadRequest("Missing phoneNumber!");
		if (region is null) return Results.BadRequest("Missing region!");

		try
		{
			var util = PhoneNumberUtil.GetInstance();
			var number = util.Parse(phoneNumber, region);
			var isValid = util.IsValidNumber(number);
			return Results.Json(new ValidateResult
			{
				IsValid = isValid,
				IsPossible = util.IsPossibleNumber(number),
				PhoneType = TypeAsString(util.GetNumberType(number)),
				InternationalFormat = util.Format(number, PhoneNumberFormat.INTERNATIONAL)
			});
		}
		catch (Exception)
		{
			return Results.Json(new ValidateResult
			{
				IsValid = false,
				IsPossible = false,
				PhoneType = TypeAsString(PhoneNumberType.UNKNOWN),
				InternationalFormat = ""
			});
		}
	}

	private static string TypeAsString(PhoneNumberType type)
	{
		var text = type.ToString().ToLower().Replace("_", " ").AsSpan();
		return string.Concat(text[0].ToString().ToUpper(), text[1..]);
	}

	internal readonly struct ValidateResult
	{
		public bool IsValid { get; init; }
		public bool IsPossible { get; init; }
		public string PhoneType { get; init; }
		public string InternationalFormat { get; init; }
	}
}
