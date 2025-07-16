namespace SidekoOctaApi63CSharpTests;

using Sdk = SidekoOctaApi63CSharp;

public class PolicydocapiHealthcheckClientTest
{
    private readonly Xunit.Abstractions.ITestOutputHelper _output;

    public PolicydocapiHealthcheckClientTest(Xunit.Abstractions.ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async void TestList200SuccessAllParams()
    {
        var client = new Sdk.Client(
            new Sdk.ClientOptions { Token = "API_TOKEN", Environment = Sdk.Environment.MockServer }
        );
        _ = await client.Policydocapi.Healthcheck.List();
    }
}
