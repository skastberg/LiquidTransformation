using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
/// <summary>
/// Extension for JsonConversion that returns a Dictionary.
/// This class was found here https://stackoverflow.com/questions/14886800/convert-jobject-into-dictionarystring-object-is-it-possible
/// All credit to Uli that provided it.
/// </summary>
public static class JsonConversionExtensions
{
    public static IDictionary<string, object> ToDictionary(this JObject json)
    {
        var propertyValuePairs = json.ToObject<Dictionary<string, object>>();
        ProcessJObjectProperties(propertyValuePairs);
        ProcessJArrayProperties(propertyValuePairs);
        return propertyValuePairs;
    }

    private static void ProcessJObjectProperties(IDictionary<string, object> propertyValuePairs)
    {
        var objectPropertyNames = (from property in propertyValuePairs
                                   let propertyName = property.Key
                                   let value = property.Value
                                   where value is JObject
                                   select propertyName).ToList();

        objectPropertyNames.ForEach(propertyName => propertyValuePairs[propertyName] = ToDictionary((JObject)propertyValuePairs[propertyName]));
    }

    private static void ProcessJArrayProperties(IDictionary<string, object> propertyValuePairs)
    {
        var arrayPropertyNames = (from property in propertyValuePairs
                                  let propertyName = property.Key
                                  let value = property.Value
                                  where value is JArray
                                  select propertyName).ToList();

        arrayPropertyNames.ForEach(propertyName => propertyValuePairs[propertyName] = ToArray((JArray)propertyValuePairs[propertyName]));
    }

    public static object[] ToArray(this JArray array)
    {
        return array.ToObject<object[]>().Select(ProcessArrayEntry).ToArray();
    }

    private static object ProcessArrayEntry(object value)
    {
        if (value is JObject)
        {
            return ToDictionary((JObject)value);
        }
        if (value is JArray)
        {
            return ToArray((JArray)value);
        }
        return value;
    }
}

