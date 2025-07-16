namespace SidekoOctaApi63CSharp.Core;

using System.Collections;
using System.Web;
using Map = Dictionary<string, object>;
using UrlParams = Dictionary<string, List<string>>;

/// <summary>
/// Provides methods for encoding URL parameters according to OpenAPI styles.
/// </summary>
public static class UrlEncoder
{
    /// <summary>
    /// Encodes a value into a URL parameter using the specified style and explode options.
    /// </summary>
    /// <param name="urlParams">The dictionary to add encoded parameters to.</param>
    /// <param name="name">The parameter name.</param>
    /// <param name="value">The parameter value (can be a primitive, list, or object).</param>
    /// <param name="style">The OpenAPI style (form, spaceDelimited, pipeDelimited, deepObject).</param>
    /// <param name="explode">Indicates whether to use explode semantics when encoding.</param>
    public static void EncodeUrlParam(
        UrlParams urlParams,
        string name,
        object? value,
        string style = "form",
        bool explode = true
    )
    {
        if (style == "form")
        {
            EncodeForm(urlParams, name, value, explode);
        }
        else if (style == "spaceDelimited")
        {
            EncodeDelimited(urlParams, name, value, explode, " ");
        }
        else if (style == "pipeDelimited")
        {
            EncodeDelimited(urlParams, name, value, explode, "|");
        }
        else if (style == "deepObject")
        {
            EncodeDeepObject(urlParams, name, value, explode);
        }
        else
        {
            throw new NotImplementedException($"url encoding style '{style}' not implemented");
        }
    }

    public static string Build(UrlParams urlParams)
    {
        var queryParts = new List<string>();
        foreach (var (name, vals) in urlParams)
        {
            var encodedName = HttpUtility.UrlEncode(name);
            foreach (var val in vals)
            {
                var encodedVal = HttpUtility.UrlEncode(val);
                queryParts.Add($"{encodedName}={encodedVal}");
            }
        }

        return string.Join("&", queryParts);
    }

    /// <summary>
    /// Encodes a value using the 'form' style with optional explode behavior.
    /// </summary>
    private static void EncodeForm(UrlParams urlParams, string name, object? value, bool explode)
    {
        if (value == null || Patch<object>.IsPatchUndefined(value))
            return;

        if (CoreUtils.IsArrayOrList(value))
        {
            IEnumerable enumerable = (IEnumerable)value;
            if (explode)
            {
                // explode form arrays/lists should be encoded like /users?id=3&id=4&id=5
                foreach (var item in enumerable)
                {
                    AddUrlParam(urlParams, name, item);
                }
            }
            else
            {
                // non-explode form arrays/lists should be encoded like /users?id=3,4,5
                var items = new List<string>();
                foreach (var item in enumerable)
                {
                    items.Add(CoreUtils.JsonStringify(item));
                }

                if (items.Count > 0)
                {
                    AddUrlParam(urlParams, name, string.Join(",", items));
                }
            }
        }
        else if (value is Map valMap)
        {
            if (explode)
            {
                // explode form objects should be encoded like /users?key0=val0&key1=val1
                // the input param name will be omitted
                foreach (var (key, val) in valMap)
                {
                    AddUrlParam(urlParams, key, val);
                }
            }
            else
            {
                // non-explode form objects should be encoded like /users?id=key0,val0,key1,val1
                var chunks = new List<string>();
                foreach (var (key, val) in valMap)
                {
                    chunks.Add(key);
                    chunks.Add(CoreUtils.JsonStringify(val));
                }

                AddUrlParam(urlParams, name, string.Join(",", chunks));
            }
        }
        else if (value is Union union)
        {
            EncodeForm(urlParams, name, union.GetValue(), explode);
        }
        else if (CoreUtils.IsSerDeClass(value))
        {
            EncodeForm(urlParams, name, CoreUtils.ConvertToMap(value), explode);
        }
        else
        {
            AddUrlParam(urlParams, name, value);
        }
    }

    /// <summary>
    /// Encodes a list using the spaceDelimited or pipeDelimited style, depending on delimiter.
    /// </summary>
    private static void EncodeDelimited(
        UrlParams urlParams,
        string name,
        object? value,
        bool explode,
        string delimiter
    )
    {
        if (value == null || Patch<object>.IsPatchUndefined(value))
            return;

        if (CoreUtils.IsArrayOrList(value) && !explode)
        {
            IEnumerable enumerable = (IEnumerable)value;
            var items = new List<string>();
            foreach (var item in enumerable)
            {
                items.Add(CoreUtils.JsonStringify(item));
            }
            if (items.Count > 0)
            {
                AddUrlParam(urlParams, name, string.Join(delimiter, items));
            }
        }
        else if (value is Union union)
        {
            EncodeDelimited(urlParams, name, union.GetValue(), explode, delimiter);
        }
        else
        {
            // according to the docs, (spaceDelimited || pipeDelimited) + explode=false only effects lists,
            // all other encodings are marked as n/a or are the same as `form` style
            // fall back on form style as it is the default for query params
            EncodeForm(urlParams, name, value, explode);
        }
    }

    /// <summary>
    /// Encodes an object using the 'deepObject' style.
    /// </summary>
    private static void EncodeDeepObject(
        UrlParams urlParams,
        string name,
        object? value,
        bool explode
    )
    {
        if (value == null || Patch<object>.IsPatchUndefined(value))
            return;

        if (CoreUtils.IsArrayOrList(value) || CoreUtils.IsSerDeClass(value) || value is Map)
        {
            EncodeDeepObjectKey(urlParams, name, value);
        }
        else if (value is Union union)
        {
            EncodeDeepObject(urlParams, name, union.GetValue(), explode);
        }
        else
        {
            // according to the docs, deepObject style only applies to
            // object/list encodes, encodings for primitives & arrays are listed as n/a,
            // fall back on form style as it is the default for query params
            EncodeForm(urlParams, name, value, explode);
        }
    }

    /// <summary>
    /// Recursively encodes keys for deepObject style parameters.
    /// </summary>
    private static void EncodeDeepObjectKey(UrlParams urlParams, string key, object? value)
    {
        if (value == null || Patch<object>.IsPatchUndefined(value))
            return;

        if (CoreUtils.IsArrayOrList(value))
        {
            IEnumerable enumerable = (IEnumerable)value;
            var i = 0;
            foreach (var item in enumerable)
            {
                EncodeDeepObjectKey(urlParams, $"{key}[{i}]", item);
                i++;
            }
        }
        else if (value is Union union)
        {
            EncodeDeepObjectKey(urlParams, key, union.GetValue());
        }
        else if (value is Map valMap)
        {
            foreach (var (mapKey, mapVal) in valMap)
            {
                EncodeDeepObjectKey(urlParams, $"{key}[{mapKey}]", mapVal);
            }
        }
        else if (CoreUtils.IsSerDeClass(value))
        {
            EncodeDeepObjectKey(urlParams, key, CoreUtils.ConvertToMap(value));
        }
        else
        {
            AddUrlParam(urlParams, key, value);
        }
    }

    /// <summary>
    /// Adds a key-value pair to the URL parameter dictionary, stringifying the value as JSON.
    /// </summary>
    private static void AddUrlParam(UrlParams urlParams, string name, object value)
    {
        var valueStr = CoreUtils.JsonStringify(value);
        if (urlParams.ContainsKey(name))
        {
            urlParams[name].Add(valueStr);
        }
        else
        {
            urlParams.Add(name, new List<string> { valueStr });
        }
    }
}
