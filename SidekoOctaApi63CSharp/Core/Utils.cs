namespace SidekoOctaApi63CSharp.Core;

using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Map = Dictionary<string, object>;

public static class CoreUtils
{
    /// <summary>
    /// Prioritizes stringifying using Newtonsoft JSON to
    /// handle complex cases like unions & enums. Falling back on
    /// standard ToString() behavior
    /// </summary>
    /// <param name="value">Value to be stringified</param>
    public static string JsonStringify(object value)
    {
        if (value is string s)
        {
            return s;
        }
        try
        {
            var jsonStr = JsonConvert.SerializeObject(value);
            return JsonStringify(JsonConvert.DeserializeObject<string>(jsonStr) ?? "");
        }
        catch
        {
            return value.ToString() ?? "";
        }
    }

    /// <summary>
    /// Uses Newtonsoft to convert an object (ideally a JSON compatible class)
    /// to a standardized Dictionary<string, object> for further parsing
    /// </summary>
    /// <param name="value">Value to be converted to a standardized Map</param>
    public static Map? ConvertToMap(object value)
    {
        return JsonConvert.DeserializeObject<Map>(JsonConvert.SerializeObject(value));
    }

    /// <summary>
    /// Uses reflection to check if an object can be iterated through
    /// </summary>
    /// <param name="value">Unknown value to check</param>
    public static bool IsArrayOrList(object value)
    {
        if (value is null)
            return false;

        var valType = value.GetType();

        return valType.IsArray
            || (valType.IsGenericType && valType.GetGenericTypeDefinition() == typeof(List<>))
            || value is JArray;
    }

    /// <summary>
    /// Uses reflection to check if an object is expected to be
    /// Serializable/Deserializable
    /// </summary>
    /// <param name="value">Unknown value to check</param>
    public static bool IsSerDeClass(object value)
    {
        var valType = value.GetType();
        return valType.IsClass
            && valType != typeof(string)
            && valType != typeof(JArray)
            && valType != typeof(JValue);
    }

    public static string? GetStringByPointer(JsonDocument json, string pointer)
    {
        JsonElement? element = GetValueByPointer(json, pointer);
        if (element == null)
        {
            return null;
        }
        else
        {
            return element?.ValueKind == JsonValueKind.String ? element?.GetString() : null;
        }
    }

    public static int? GetIntByPointer(JsonDocument json, string pointer)
    {
        JsonElement? element = GetValueByPointer(json, pointer);
        if (element == null)
        {
            return null;
        }
        else
        {
            return element?.ValueKind == JsonValueKind.Number ? element?.GetInt32() : null;
        }
    }

    public static JsonElement? GetValueByPointer(JsonDocument json, string pointer)
    {
        JsonElement current = json.RootElement;

        foreach (var token in pointer.Trim('/').Split('/'))
        {
            var unescaped = token.Replace("~1", "/").Replace("~0", "~");
            if (
                current.ValueKind == JsonValueKind.Object
                && current.TryGetProperty(unescaped, out var next)
            )
            {
                current = next;
            }
            else
            {
                return null; // Not found or not an object
            }
        }

        return current;
    }
}
