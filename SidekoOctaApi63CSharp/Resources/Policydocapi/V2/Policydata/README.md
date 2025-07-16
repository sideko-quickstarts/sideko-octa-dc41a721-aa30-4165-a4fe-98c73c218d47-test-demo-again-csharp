
### POST /policydocapi/v2/policydata <a name="create"></a>

Get policy data and documents

**API Endpoint**: `POST /policydocapi/v2/policydata`

#### Parameters

| Parameter | Required | Description | Example |
|-----------|:--------:|-------------|--------|
| `data` | ✗ |  | `new SearchCriteria {}` |

#### Example Snippet

```csharp
using Sdk = SidekoOctaApi63CSharp;

var client = new Sdk.Client(
    new Sdk.ClientOptions { Token = Environment.GetEnvironmentVariable("API_TOKEN")! }
);
var res = await client.Policydocapi.V2.Policydata.Create();

```

#### Response

##### Type
[ResponsePayload](/SidekoOctaApi63CSharp/Types/ResponsePayload.cs)

##### Example
`new ResponsePayload {}`
