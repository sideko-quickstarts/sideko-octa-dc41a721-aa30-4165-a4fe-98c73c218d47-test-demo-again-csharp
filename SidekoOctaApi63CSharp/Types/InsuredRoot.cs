namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// InsuredRoot
/// </summary>
public class InsuredRoot
{
    [NJ.JsonProperty(
        "address",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public Address? Address { get; set; }

    /// <summary>
    /// Insured Business Name
    /// </summary>
    [NJ.JsonProperty(
        "name",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? Name { get; set; }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
