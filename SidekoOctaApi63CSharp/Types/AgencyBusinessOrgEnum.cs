namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;
using SRS = System.Runtime.Serialization;

/// <summary>
/// Defines the market segment (AA vs BB)
/// </summary>
[NJ.JsonConverter(typeof(NJ.Converters.StringEnumConverter))]
public enum AgencyBusinessOrgEnum
{
    [SRS.EnumMember(Value = "AA")]
    Aa,

    [SRS.EnumMember(Value = "BB")]
    Bb,
}
