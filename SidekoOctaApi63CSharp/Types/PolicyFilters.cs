namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// PolicyFilters
/// </summary>
public class PolicyFilters
{
    /// <summary>
    /// Identifies between policy views. Difference views provide different levels of document transparency.
    /// </summary>
    [NJ.JsonProperty(
        "setTypes",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public List<string>? SetTypes { get; set; }

    /// <summary>
    /// Policy/endorsement/cancellation end date
    /// </summary>
    [NJ.JsonProperty(
        "transactionEndDate",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? TransactionEndDate { get; set; }

    /// <summary>
    /// Policy/endorsement inception date
    /// </summary>
    [NJ.JsonProperty(
        "transactionStartDate",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? TransactionStartDate { get; set; }

    /// <summary>
    /// Assigned codes to distinguish between policy types & milestones
    /// </summary>
    [NJ.JsonProperty(
        "transactionTypes",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public List<string>? TransactionTypes { get; set; }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
