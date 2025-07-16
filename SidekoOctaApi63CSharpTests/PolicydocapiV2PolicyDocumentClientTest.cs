namespace SidekoOctaApi63CSharpTests;

using Resource = SidekoOctaApi63CSharp.Resources.Policydocapi.V2.PolicyDocument;
using Sdk = SidekoOctaApi63CSharp;

public class PolicydocapiV2PolicyDocumentClientTest
{
    private readonly Xunit.Abstractions.ITestOutputHelper _output;

    public PolicydocapiV2PolicyDocumentClientTest(Xunit.Abstractions.ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async void TestGet200SuccessAllParams()
    {
        var client = new Sdk.Client(
            new Sdk.ClientOptions { Token = "API_TOKEN", Environment = Sdk.Environment.MockServer }
        );
        _ = await client.Policydocapi.V2.PolicyDocument.Get(
            new Resource.GetRequest
            {
                DocumentId = 12345,
                SetType = Sdk.Types.PolicydocapiV2PolicyDocumentGetSetTypeEnum.A,
            }
        );
    }
}
