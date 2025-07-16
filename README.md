
# Agency Digital Business Platform - Exp -Policy API Csharp SDK

## Overview
This API will used by Agencies to get policy documents and metadata

#### Example Client Initialization

```csharp
using Sdk = SidekoOctaApi63CSharp;

var client = new Sdk.Client(
    new Sdk.ClientOptions { Token = Environment.GetEnvironmentVariable("API_TOKEN")! }
);
```

## Module Documentation and Snippets

### [Policydocapi.Healthcheck](SidekoOctaApi63CSharp/Resources/Policydocapi/Healthcheck/README.md)

* [list](SidekoOctaApi63CSharp/Resources/Policydocapi/Healthcheck/README.md#list) - GET /policydocapi/healthcheck

### [Policydocapi.Policydata](SidekoOctaApi63CSharp/Resources/Policydocapi/Policydata/README.md)

* [create](SidekoOctaApi63CSharp/Resources/Policydocapi/Policydata/README.md#create) - POST /policydocapi/policydata

### [Policydocapi.V2.PolicyDocument](SidekoOctaApi63CSharp/Resources/Policydocapi/V2/PolicyDocument/README.md)

* [get](SidekoOctaApi63CSharp/Resources/Policydocapi/V2/PolicyDocument/README.md#get) - GET /policydocapi/v2/policy-document/{documentId}/{setType}

### [Policydocapi.V2.Policydata](SidekoOctaApi63CSharp/Resources/Policydocapi/V2/Policydata/README.md)

* [create](SidekoOctaApi63CSharp/Resources/Policydocapi/V2/Policydata/README.md#create) - POST /policydocapi/v2/policydata

<!-- MODULE DOCS END -->
