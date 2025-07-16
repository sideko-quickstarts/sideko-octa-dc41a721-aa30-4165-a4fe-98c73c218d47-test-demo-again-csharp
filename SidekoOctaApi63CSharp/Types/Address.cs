namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// Address
/// </summary>
public class Address
{
    /// <summary>
    /// Address city.
    /// </summary>
    [NJ.JsonProperty(
        "city",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? City { get; set; }

    /// <summary>
    /// The country code of the address.
    /// </summary>
    [NJ.JsonProperty(
        "countryCode",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? CountryCode { get; set; }

    /// <summary>
    /// The country name of the address.
    /// </summary>
    [NJ.JsonProperty(
        "countryName",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? CountryName { get; set; }

    /// <summary>
    /// Address Line 1.
    /// </summary>
    [NJ.JsonProperty(
        "line1",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? Line1 { get; set; }

    /// <summary>
    /// Address Line 2
    /// </summary>
    [NJ.JsonProperty(
        "line2",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? Line2 { get; set; }

    /// <summary>
    /// The postal code of the address.
    /// </summary>
    [NJ.JsonProperty(
        "postalCode",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? PostalCode { get; set; }

    /// <summary>
    /// The state code of the address.
    /// </summary>
    [NJ.JsonProperty(
        "stateOrProvinceCode",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? StateOrProvinceCode { get; set; }

    /// <summary>
    /// The state name of the address.
    /// </summary>
    [NJ.JsonProperty(
        "stateOrProvinceName",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? StateOrProvinceName { get; set; }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
