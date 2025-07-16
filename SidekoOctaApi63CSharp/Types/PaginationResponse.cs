namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// PaginationResponse
/// </summary>
public class PaginationResponse
{
    /// <summary>
    /// The number of records to return per call.
    /// </summary>
    [NJ.JsonProperty(
        "batchSize",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public int? BatchSize { get; set; }

    /// <summary>
    /// The current batch number of the paginated set
    /// </summary>
    [NJ.JsonProperty(
        "currentBatch",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public int? CurrentBatch { get; set; }

    /// <summary>
    /// Total number of batches
    /// </summary>
    [NJ.JsonProperty(
        "totalBatches",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public int? TotalBatches { get; set; }

    /// <summary>
    /// Total number of records
    /// </summary>
    [NJ.JsonProperty(
        "totalRecords",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public int? TotalRecords { get; set; }

    /// <summary>
    /// The current batch number of the paginated set
    /// </summary>
    [NJ.JsonProperty("transactionId", Required = NJ.Required.Default)]
    [NJ.JsonConverter(typeof(Core.PatchJsonConverter<string>))]
    public Core.Patch<string> TransactionId { get; set; } = Core.Patch<string>.Undefined();

    /// <summary>
    /// Policy/endorsement/cancellation end date
    /// </summary>
    [NJ.JsonProperty(
        "transactionIdExpiryDate",
        Required = NJ.Required.Default,
        NullValueHandling = NJ.NullValueHandling.Ignore
    )]
    public string? TransactionIdExpiryDate { get; set; }

    public bool ShouldSerializeTransactionId()
    {
        return !this.TransactionId.IsUndefined();
    }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
