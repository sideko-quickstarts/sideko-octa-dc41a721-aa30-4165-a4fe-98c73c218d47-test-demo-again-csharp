namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// AgentRoot
/// </summary>
public class AgentRoot
{
    [NJ.JsonProperty(
        "address",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public Address? Address { get; set; }

    /// <summary>
    /// Insured or Agent copy - example showing "Agent"
    /// </summary>
    [NJ.JsonProperty(
        "agentSetType",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? AgentSetType { get; set; }

    /// <summary>
    /// Agency Business Name
    /// </summary>
    [NJ.JsonProperty(
        "name",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? Name { get; set; }

    /// <summary>
    /// Unique alphanumeric Agency identifier
    /// </summary>
    [NJ.JsonProperty(
        "producerCode",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? ProducerCode { get; set; }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
