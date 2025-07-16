namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;
using SRS = System.Runtime.Serialization;

/// <summary>
/// Requestpayload
/// </summary>
public class Requestpayload
{
    /// <summary>
    /// Agency Business Name
    /// </summary>
    [NJ.JsonProperty("agencyIdentifier", Required = NJ.Required.Always)]
    public string AgencyIdentifier { get; set; } = string.Empty;

    /// <summary>
    /// The page number to fetch the next set of records
    /// </summary>
    [NJ.JsonProperty("batchNumber", Required = NJ.Required.Always)]
    public int BatchNumber { get; set; }

    /// <summary>
    /// The number of records to return per call.
    /// </summary>
    [NJ.JsonProperty("batchSize", Required = NJ.Required.Always)]
    public int BatchSize { get; set; }

    /// <summary>
    /// Policy/endorsement/cancellation end date
    /// </summary>
    [NJ.JsonProperty("endDate", Required = NJ.Required.Always)]
    public string EndDate { get; set; } = string.Empty;

    /// <summary>
    /// Unique alpha numeric or numeric code assigned to an Agency by the insurer
    /// </summary>
    [NJ.JsonProperty("producerCodes", Required = NJ.Required.Always)]
    public List<string> ProducerCodes { get; set; } = new();

    /// <summary>
    /// Identifies between insured or agent policy views. Different views provide different levels of document transparency
    /// </summary>
    [NJ.JsonProperty("setTypes", Required = NJ.Required.Always)]
    public List<string> SetTypes { get; set; } = new();

    /// <summary>
    /// Policy/endorsement inception date
    /// </summary>
    [NJ.JsonProperty("startDate", Required = NJ.Required.Always)]
    public string StartDate { get; set; } = string.Empty;

    /// <summary>
    /// Assigned codes to distinguish between policy types & milestones
    /// </summary>
    [NJ.JsonProperty("transactionTypes", Required = NJ.Required.Always)]
    public List<string> TransactionTypes { get; set; } = new();

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
