#region

using System.Globalization;
using PhoneNumbers;
using static PhoneNumbers.PhoneNumberUtil;
using static System.Convert;

#endregion

namespace BusinessLogic.BL_Validation;

public static class PhoneValidation
{
    private static int GetCountryDigits(string countryName)
    {
        return GetInstance().GetCountryCodeForRegion(countryName.ToUpper());
    }

    public static string GetExtension(string phone, string defaultRegion)
    {
        return $"{GetInstance().GetCountryCodeForRegion(GetInstance().GetRegionCodeForNumber(GetInstance().Parse(phone, defaultRegion)))}";
    }
	/// <summary>
	/// 
	/// </summary>
	/// <returns>sets of values like NL,+31 (+31 will be displayed in combobox)(NL is used in CheckPhone()</returns>
    public static Dictionary<string, string> GetNamesAndCode()
    {
        return CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID)).Select(x =>
            new[] { new { Name = x.TwoLetterISORegionName, Code = $"+{GetCountryDigits(x.TwoLetterISORegionName)}" } }).SelectMany(x => x).DistinctBy(x => x.Code).OrderBy(x => ToInt32(x.Code.Trim('+'))).ToDictionary(x => x.Name, x => x.Code); 
    }

    public static bool CheckPhone(string phoneNo, string region)
    {
        return GetInstance().IsValidNumberForRegion(GetInstance().Parse(phoneNo, region), region);
    }

    public static string International(string phoneNo, string region)
    {
        return GetInstance().Format(GetInstance().Parse(phoneNo, region), PhoneNumberFormat.INTERNATIONAL);
    }
}