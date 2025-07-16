namespace SidekoOctaApi63CSharp.Resources.Policydocapi;

using HealthcheckResource = SidekoOctaApi63CSharp.Resources.Policydocapi.Healthcheck;
using PolicydataResource = SidekoOctaApi63CSharp.Resources.Policydocapi.Policydata;
using V2Resource = SidekoOctaApi63CSharp.Resources.Policydocapi.V2;

public class Client
{
    public HealthcheckResource.Client Healthcheck { get; private set; }
    public V2Resource.Client V2 { get; private set; }
    public PolicydataResource.Client Policydata { get; private set; }

    private Core.BaseClient baseClient;

    public Client(Core.BaseClient baseClient)
    {
        this.baseClient = baseClient;

        this.Healthcheck = new HealthcheckResource.Client(this.baseClient);
        this.V2 = new V2Resource.Client(this.baseClient);
        this.Policydata = new PolicydataResource.Client(this.baseClient);
    }
}
