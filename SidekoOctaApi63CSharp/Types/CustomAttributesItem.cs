namespace SidekoOctaApi63CSharp.Types;

using NJ = Newtonsoft.Json;

/// <summary>
/// CustomAttributesItem
/// </summary>
public class CustomAttributesItem
{
    /// <summary>
    /// The key of the key-value pair transactionFunctionCode: Policy/ milestone type - example showing "Renewal" naicCd: Numeric identifier used to reflect Insuring Company (# only used internally) adbpTypeCd: Travelers description associated with transaction function code insuringCompany: The company that will write the policy that was created for this proposal
    /// </summary>
    [NJ.JsonProperty("key", Required = NJ.Required.Always)]
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// The value of the key-value pair
    /// </summary>
    [NJ.JsonProperty("value", Required = NJ.Required.Always)]
    public string Value { get; set; } = string.Empty;

    public override string ToString()
    {
        return NJ.JsonConvert.SerializeObject(this);
    }
}
