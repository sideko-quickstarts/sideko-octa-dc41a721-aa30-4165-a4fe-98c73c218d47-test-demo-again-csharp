namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;
using SRS = System.Runtime.Serialization;

/// <summary>
/// Document set type
/// </summary>
[NJ.JsonConverter(typeof(NJ.Converters.StringEnumConverter))]
public enum PolicydocapiV2PolicyDocumentGetSetTypeEnum
{
    [SRS.EnumMember(Value = "A")]
    A,

    [SRS.EnumMember(Value = "I")]
    I,
}
