namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// AcordLob
/// </summary>
public class AcordLob
{
    /// <summary>
    /// Accord Line of Buisness description
    /// </summary>
    [NJ.JsonProperty(
        "acordLOBCode",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? AcordLobCode { get; set; }

    /// <summary>
    /// Accord Line of Buisness description
    /// </summary>
    [NJ.JsonProperty(
        "businessGroup",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? BusinessGroup { get; set; }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
