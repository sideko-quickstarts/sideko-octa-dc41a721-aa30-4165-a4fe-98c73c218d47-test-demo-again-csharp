namespace SidekoOctaApi63CSharp.Resources.Policydocapi.V2.Policydata;

using NJ = Newtonsoft.Json;

/// <summary>
/// CreateRequest
/// </summary>
public class CreateRequest
{
    [NJ.JsonProperty(
        "data",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public Types.SearchCriteria? Data { get; set; }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
