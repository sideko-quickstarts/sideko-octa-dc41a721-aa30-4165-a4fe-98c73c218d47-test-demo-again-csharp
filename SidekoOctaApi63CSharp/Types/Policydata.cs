namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;
using SRS = System.Runtime.Serialization;

/// <summary>
/// Policydata
/// </summary>
public class Policydata
{
    /// <summary>
    /// Travelers description associated with transaction function code
    /// </summary>
    [NJ.JsonProperty(
        "adbpTypeCd",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? AdbpTypeCd { get; set; }

    /// <summary>
    /// Agency Business Name
    /// </summary>
    [NJ.JsonProperty(
        "agencyName",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? AgencyName { get; set; }

    /// <summary>
    /// Identifies between insured or agent policy views. Different views provide different levels of document transparency
    /// </summary>
    [NJ.JsonProperty(
        "agentSetType",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? AgentSetType { get; set; }

    /// <summary>
    /// Encrypted Document
    /// </summary>
    [NJ.JsonProperty(
        "document",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? Document { get; set; }

    /// <summary>
    /// Full document reference name
    /// </summary>
    [NJ.JsonProperty(
        "documentDesc",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? DocumentDesc { get; set; }

    /// <summary>
    /// Full document reference name
    /// </summary>
    [NJ.JsonProperty(
        "documentName",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? DocumentName { get; set; }

    /// <summary>
    /// Document file size
    /// </summary>
    [NJ.JsonProperty(
        "fileSize",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public double? FileSize { get; set; }

    /// <summary>
    /// Insured Entity or Individual Name
    /// </summary>
    [NJ.JsonProperty(
        "insuredsNameLine1",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? InsuredsNameLine1 { get; set; }

    /// <summary>
    /// Writing Company
    /// </summary>
    [NJ.JsonProperty(
        "insuringCompany",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? InsuringCompany { get; set; }

    /// <summary>
    /// A code identifying the line of business classification
    /// </summary>
    [NJ.JsonProperty(
        "lobCd",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? LobCd { get; set; }

    /// <summary>
    /// Numeric identifier used to reflect Insuring Company
    /// </summary>
    [NJ.JsonProperty(
        "naicCd",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? NaicCd { get; set; }

    /// <summary>
    /// This is an effective date, the explicit meaning of which is implied by its parent or usage. As used here, this is the effective date of this coverage.
    /// </summary>
    [NJ.JsonProperty(
        "policyEffectiveDate",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? PolicyEffectiveDate { get; set; }

    /// <summary>
    /// This is an expiration or termination date, the explicit meaning of which is implied by its parent or its usage. As used here, this is the expiration date of this coverage.
    /// </summary>
    [NJ.JsonProperty(
        "policyExpirationDate",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? PolicyExpirationDate { get; set; }

    /// <summary>
    /// A code that identifies the type of policy as it would normally be identified on a coverage level
    /// </summary>
    [NJ.JsonProperty(
        "policyForm",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? PolicyForm { get; set; }

    /// <summary>
    /// The unique number assigned to the policy, or submission, being referenced.
    /// </summary>
    [NJ.JsonProperty(
        "policyNumber",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? PolicyNumber { get; set; }

    /// <summary>
    /// Unique alpha numeric or numeric code assigned to an Agency by the insurer
    /// </summary>
    [NJ.JsonProperty(
        "producerCode",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? ProducerCode { get; set; }

    /// <summary>
    /// The date on which the referenced transaction takes effect
    /// </summary>
    [NJ.JsonProperty(
        "transactionEffectiveDate",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? TransactionEffectiveDate { get; set; }

    /// <summary>
    /// Policy/ milestone type - example showing "Renewal"
    /// </summary>
    [NJ.JsonProperty(
        "transactionFunctionCode",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? TransactionFunctionCode { get; set; }

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
