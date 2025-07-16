namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// Agency
/// </summary>
public class Agency
{
    /// <summary>
    /// Defines the market segment (AA vs BB)
    /// </summary>
    [NJ.JsonProperty(
        "businessOrg",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public AgencyBusinessOrgEnum? BusinessOrg { get; set; }

    /// <summary>
    /// Unique numeric code assigned to each Agency when onboarding to Travelers
    /// </summary>
    [NJ.JsonProperty(
        "producerCodes",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public List<string>? ProducerCodes { get; set; }

    /// <summary>
    /// Agency Short Name
    /// </summary>
    [NJ.JsonProperty(
        "shortCode",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? ShortCode { get; set; }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
