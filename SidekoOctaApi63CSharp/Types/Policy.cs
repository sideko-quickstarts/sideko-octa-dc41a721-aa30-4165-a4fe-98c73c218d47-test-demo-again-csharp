namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// Policy
/// </summary>
public class Policy
{
    [NJ.JsonProperty(
        "acordLOB",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public AcordLob? AcordLob { get; set; }

    [NJ.JsonProperty(
        "agent",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public AgentRoot? Agent { get; set; }

    [NJ.JsonProperty(
        "customAttributes",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public List<CustomAttributesItem>? CustomAttributes { get; set; }

    [NJ.JsonProperty(
        "document",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public Document? Document { get; set; }

    /// <summary>
    /// The policy expiration date of the policy that was created for this proposal.
    /// </summary>
    [NJ.JsonProperty(
        "effectiveDate",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? EffectiveDate { get; set; }

    /// <summary>
    /// The policy effective date of the policy that was created for this proposal.
    /// </summary>
    [NJ.JsonProperty(
        "expiryDate",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? ExpiryDate { get; set; }

    /// <summary>
    /// The policy form of the policy that was created for this proposal.
    /// </summary>
    [NJ.JsonProperty(
        "form",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? Form { get; set; }

    /// <summary>
    /// The unique database identifier assigned to the policy, or submission, being referenced
    /// </summary>
    [NJ.JsonProperty(
        "id",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public int? Id { get; set; }

    [NJ.JsonProperty(
        "insured",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public InsuredRoot? Insured { get; set; }

    /// <summary>
    /// The company that will write the policy that was created for this proposal.
    /// </summary>
    [NJ.JsonProperty(
        "insuringCompany",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? InsuringCompany { get; set; }

    /// <summary>
    /// The policy effective date of the policy that was created for this proposal.
    /// </summary>
    [NJ.JsonProperty(
        "issueDate",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? IssueDate { get; set; }

    /// <summary>
    /// The unique number assigned to the policy, or submission, being referenced
    /// </summary>
    [NJ.JsonProperty(
        "number",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? Number { get; set; }

    /// <summary>
    /// The policy expiration date of the policy that was created for this proposal.
    /// </summary>
    [NJ.JsonProperty(
        "transactionEffectiveDate",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? TransactionEffectiveDate { get; set; }

    /// <summary>
    /// Hard coded value derived from policy form numeric
    /// </summary>
    [NJ.JsonProperty(
        "type",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? Type { get; set; }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
