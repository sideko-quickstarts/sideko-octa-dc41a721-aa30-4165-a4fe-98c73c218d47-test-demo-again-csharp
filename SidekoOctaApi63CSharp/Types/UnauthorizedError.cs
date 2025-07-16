namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;
using SRS = System.Runtime.Serialization;

/// <summary>
/// Access token is missing or invalid
/// </summary>
public class UnauthorizedError
{
    [NJ.JsonProperty(
        "message",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? Message { get; set; }

    [NJ.JsonExtensionData]
    public Dictionary<string, NJ.Linq.JToken> _additionalProperties =
        new Dictionary<string, NJ.Linq.JToken>(); // captures any additional key-val pairs

    [NJ.JsonIgnore]
    public Dictionary<string, Object> AdditionalProperties = new Dictionary<string, Object>(); // casts additional key-val pairs to anticipated types

    [SRS.OnSerializing]
    internal void BeforeSerialize(SRS.StreamingContext context)
    {
        // sync public typed AdditionalProperties to generic _additionalProperties
        // for serialization
        this._additionalProperties = new Dictionary<string, NJ.Linq.JToken>();
        foreach (var kvp in AdditionalProperties)
        {
            this._additionalProperties[kvp.Key] = NJ.Linq.JToken.FromObject(kvp.Value);
        }
    }

    [SRS.OnDeserialized]
    internal void OnDeserializedMethod(SRS.StreamingContext context)
    {
        // cast generic _additionalProperties to typed AdditionalProperties
        // after deserialization

        foreach (var kvp in this._additionalProperties)
        {
            try
            {
                var obj = kvp.Value.ToObject<Object>();
                AdditionalProperties[kvp.Key] = obj!;
            }
            catch (NJ.JsonException ex)
            {
                throw new NJ.JsonSerializationException(
                    $"Invalid additional property '{kvp.Key}': {kvp.Value}",
                    ex
                );
            }
        }
    }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
