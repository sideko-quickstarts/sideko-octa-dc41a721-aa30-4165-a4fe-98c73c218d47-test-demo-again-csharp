
### GET /policydocapi/v2/policy-document/{documentId}/{setType} <a name="get"></a>

Check the health of an API

**API Endpoint**: `GET /policydocapi/v2/policy-document/{documentId}/{setType}`

#### Parameters

| Parameter | Required | Description | Example |
|-----------|:--------:|-------------|--------|
| `documentId` | ✓ | Document Identifier | `12345` |
| `setType` | ✓ | Document set type | `PolicydocapiV2PolicyDocumentGetSetTypeEnum.A` |

#### Example Snippet

```csharp
using Resource = SidekoOctaApi63CSharp.Resources.Policydocapi.V2.PolicyDocument;
using Sdk = SidekoOctaApi63CSharp;

var client = new Sdk.Client(
    new Sdk.ClientOptions { Token = Environment.GetEnvironmentVariable("API_TOKEN")! }
);
var res = await client.Policydocapi.V2.PolicyDocument.Get(
    new Resource.GetRequest
    {
        DocumentId = 12345,
        SetType = Sdk.Types.PolicydocapiV2PolicyDocumentGetSetTypeEnum.A,
    }
);

```
