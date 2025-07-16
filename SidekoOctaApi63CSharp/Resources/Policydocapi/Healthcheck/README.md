
### GET /policydocapi/healthcheck <a name="list"></a>

Check the health of an API

**API Endpoint**: `GET /policydocapi/healthcheck`

#### Example Snippet

```csharp
using Sdk = SidekoOctaApi63CSharp;

var client = new Sdk.Client(
    new Sdk.ClientOptions { Token = Environment.GetEnvironmentVariable("API_TOKEN")! }
);
var res = await client.Policydocapi.Healthcheck.List();

```

#### Response

##### Type
[HealthCheckSuccessResponse](/SidekoOctaApi63CSharp/Types/HealthCheckSuccessResponse.cs)

##### Example
`new HealthCheckSuccessResponse {Message = "ALIVE"}`
