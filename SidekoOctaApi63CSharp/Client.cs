namespace SidekoOctaApi63CSharp;

using PolicydocapiResource = SidekoOctaApi63CSharp.Resources.Policydocapi;

public class ClientOptions
{
    public string? Token { get; set; }
    public Environment Environment { get; set; } = Environment.Environment_;
    public double? Timeout { get; set; }
}

public class Client
{
    public PolicydocapiResource.Client Policydocapi { get; private set; }
    private Core.BaseClient baseClient;

    public Client()
        : this(new ClientOptions { }) { }

    public Client(ClientOptions opts)
    {
        this.baseClient = new Core.BaseClient(opts.Environment.Url, opts.Timeout);
        this.baseClient.RegisterAuth("bearerAuth", new Core.AuthBearer(token: opts.Token));

        this.Policydocapi = new PolicydocapiResource.Client(this.baseClient);
    }
}
