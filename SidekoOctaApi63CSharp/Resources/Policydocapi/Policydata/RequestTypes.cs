namespace SidekoOctaApi63CSharp.Resources.Policydocapi.Policydata;

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
    public Types.Requestpayload? Data { get; set; }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
