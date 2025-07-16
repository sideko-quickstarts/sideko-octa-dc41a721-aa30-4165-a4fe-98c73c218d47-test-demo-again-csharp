namespace SidekoOctaApi63CSharp.Resources.Policydocapi.V2.PolicyDocument;

using NJ = Newtonsoft.Json;

/// <summary>
/// GetRequest
/// </summary>
public class GetRequest
{
    /// <summary>
    /// Document Identifier
    /// </summary>
    [NJ.JsonProperty("documentId", Required = NJ.Required.Always)]
    public int DocumentId { get; set; }

    /// <summary>
    /// Document set type
    /// </summary>
    [NJ.JsonProperty("setType", Required = NJ.Required.Always)]
    public Types.PolicydocapiV2PolicyDocumentGetSetTypeEnum SetType { get; set; }

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
