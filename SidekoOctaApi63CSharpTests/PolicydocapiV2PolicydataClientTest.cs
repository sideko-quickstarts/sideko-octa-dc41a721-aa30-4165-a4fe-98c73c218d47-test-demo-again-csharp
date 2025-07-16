namespace SidekoOctaApi63CSharpTests;

using Sdk = SidekoOctaApi63CSharp;

public class PolicydocapiV2PolicydataClientTest
{
    private readonly Xunit.Abstractions.ITestOutputHelper _output;

    public PolicydocapiV2PolicydataClientTest(Xunit.Abstractions.ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async void TestCreate200SuccessAllParams()
    {
        var client = new Sdk.Client(
            new Sdk.ClientOptions { Token = "API_TOKEN", Environment = Sdk.Environment.MockServer }
        );
        _ = await client.Policydocapi.V2.Policydata.Create();
    }
}
