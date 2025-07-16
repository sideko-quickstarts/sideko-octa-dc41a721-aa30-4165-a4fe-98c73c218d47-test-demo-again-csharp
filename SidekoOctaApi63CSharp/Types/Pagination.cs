namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// Pagination
/// </summary>
public class Pagination
{
    /// <summary>
    /// The current batch number of the paginated set
    /// </summary>
    [NJ.JsonProperty("batchNumber", Required = NJ.Required.Default)]
    [NJ.JsonConverter(typeof(Core.PatchJsonConverter<int>))]
    public Core.Patch<int> BatchNumber { get; set; } = Core.Patch<int>.Undefined();

    /// <summary>
    /// The current batch number of the paginated set
    /// </summary>
    [NJ.JsonProperty("transactionId", Required = NJ.Required.Default)]
    [NJ.JsonConverter(typeof(Core.PatchJsonConverter<string>))]
    public Core.Patch<string> TransactionId { get; set; } = Core.Patch<string>.Undefined();

    public bool ShouldSerializeBatchNumber()
    {
        return !this.BatchNumber.IsUndefined();
    }

    public bool ShouldSerializeTransactionId()
    {
        return !this.TransactionId.IsUndefined();
    }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
