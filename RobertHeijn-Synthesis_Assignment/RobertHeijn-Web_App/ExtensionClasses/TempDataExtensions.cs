#region

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

#endregion

namespace RobertHeijn_Web_App.ExtensionClasses;

public static class TempDataExtensions
{
    public static void Set<T>(this ITempDataDictionary tempData, string key, T value) where T : class
    {
        tempData[key] = JsonConvert.SerializeObject(value);
    }

    public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
    {
        var o = tempData[key]!.ToString()!;
        return (o == string.Empty ? default(T) : JsonConvert.DeserializeObject<T>(o)!)!;
    }
}