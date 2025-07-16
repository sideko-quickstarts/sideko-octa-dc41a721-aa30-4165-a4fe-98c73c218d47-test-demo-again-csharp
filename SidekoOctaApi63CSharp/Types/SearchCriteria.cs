namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// SearchCriteria
/// </summary>
public class SearchCriteria
{
    [NJ.JsonProperty(
        "agency",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public Agency? Agency { get; set; }

    [NJ.JsonProperty(
        "pagination::",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public Pagination? Pagination { get; set; }

    [NJ.JsonProperty(
        "policyFilters:",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public PolicyFilters? PolicyFilters { get; set; }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
