
### POST /policydocapi/policydata <a name="create"></a>

Get policy data and documents

**API Endpoint**: `POST /policydocapi/policydata`

#### Parameters

| Parameter | Required | Description | Example |
|-----------|:--------:|-------------|--------|
| `data` | ✗ |  | `new Requestpayload {AgencyIdentifier = "TEST_01", BatchNumber = 1, BatchSize = 10, EndDate = "13-Apr-2023 10:00:00", ProducerCodes = new List<string> {"0oooo1", "0oooo2"}, SetTypes = new List<string> {"A", "I"}, StartDate = "12-Apr-2023 21:30:00", TransactionTypes = new List<string> {"P30", "P99", "P2"}}` |

#### Example Snippet

```csharp
using Sdk = SidekoOctaApi63CSharp;

var client = new Sdk.Client(
    new Sdk.ClientOptions { Token = Environment.GetEnvironmentVariable("API_TOKEN")! }
);
var res = await client.Policydocapi.Policydata.Create();

```

#### Response

##### Type
List of [Policydata](/SidekoOctaApi63CSharp/Types/Policydata.cs)

##### Example
`new List<Policydata> {new Policydata {AdbpTypeCd = "RWL", AgencyName = "TEST_NASA_AGENCY", AgentSetType = "A", Document = "AAAAFDGh87whmnjgrmklfkJNKHKVMKOV37483FN7NMN34N3MSNKS", DocumentDesc = "RWL_Renewal_CUP8R000123UMBRC_20220601_Annie_Easley_Research_Center_A", DocumentName = "RWL_Renewal_CUP8R000123UMBRC_20220601_Annie_Easley_Research_Center_A", FileSize = 9869.0, InsuredsNameLine1 = "Annie_Easley_Research_Center", InsuringCompany = "TIL", LobCd = "UMBRC", NaicCd = "274", PolicyEffectiveDate = "01-Jun-2022 04:00:00", PolicyExpirationDate = "01-Jun-2023 04:00:00", PolicyForm = "CUP", PolicyNumber = "CUP8R000123", ProducerCode = "0TE098", TransactionEffectiveDate = "01-Jul-2022 04:00:00", TransactionFunctionCode = "P2"}}`
