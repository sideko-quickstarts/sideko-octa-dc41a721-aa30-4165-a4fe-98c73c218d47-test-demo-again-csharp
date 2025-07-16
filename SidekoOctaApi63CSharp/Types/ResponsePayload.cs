namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// ResponsePayload
/// </summary>
public class ResponsePayload
{
    [NJ.JsonProperty(
        "pagination",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public PaginationResponse? Pagination { get; set; }

    [NJ.JsonProperty(
        "policies",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public List<Policy>? Policies { get; set; }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
