namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// Document
/// </summary>
public class Document
{
    /// <summary>
    /// Full document reference name
    /// </summary>
    [NJ.JsonProperty(
        "description",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? Description { get; set; }

    /// <summary>
    /// S3 URL
    /// </summary>
    [NJ.JsonProperty(
        "downloadUrl",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? DownloadUrl { get; set; }

    /// <summary>
    /// S3 URL Expiry date
    /// </summary>
    [NJ.JsonProperty(
        "downloadUrlExpiryTimeUTC",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? DownloadUrlExpiryTimeUtc { get; set; }

    /// <summary>
    /// Full document reference name
    /// </summary>
    [NJ.JsonProperty(
        "name",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? Name { get; set; }

    /// <summary>
    /// Document type
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
