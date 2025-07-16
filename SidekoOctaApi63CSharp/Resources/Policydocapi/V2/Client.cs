namespace SidekoOctaApi63CSharp.Resources.Policydocapi.V2;

using PolicydataResource = SidekoOctaApi63CSharp.Resources.Policydocapi.V2.Policydata;
using PolicyDocumentResource = SidekoOctaApi63CSharp.Resources.Policydocapi.V2.PolicyDocument;

public class Client
{
    public PolicyDocumentResource.Client PolicyDocument { get; private set; }
    public PolicydataResource.Client Policydata { get; private set; }

    private Core.BaseClient baseClient;

    public Client(Core.BaseClient baseClient)
    {
        this.baseClient = baseClient;

        this.PolicyDocument = new PolicyDocumentResource.Client(this.baseClient);
        this.Policydata = new PolicydataResource.Client(this.baseClient);
    }
}
