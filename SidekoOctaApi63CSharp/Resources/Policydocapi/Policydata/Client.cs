namespace SidekoOctaApi63CSharp.Resources.Policydocapi.Policydata;

public class Client
{
    private Core.BaseClient baseClient;

    public Client(Core.BaseClient baseClient)
    {
        this.baseClient = baseClient;
    }

    /// <summary>
    /// Get policy data and documents
    ///
    /// POST /policydocapi/policydata
    /// </summary>
    public async Task<List<Types.Policydata>> Create(Core.RequestOptions? reqOpts = null)
    {
        return await Create(new CreateRequest(), reqOpts);
    }

    /// <summary>
    /// Get policy data and documents
    ///
    /// POST /policydocapi/policydata
    /// </summary>
    public async Task<List<Types.Policydata>> Create(
        CreateRequest req,
        Core.RequestOptions? reqOpts = null
    )
    {
        var builder = new Core.RequestBuilder(
            method: HttpMethod.Post,
            baseUrl: this.baseClient.GetBaseUrl(),
            path: "/policydocapi/policydata",
            timeout: this.baseClient.Timeout,
            opts: reqOpts
        );
        await builder.AddAuths(this.baseClient.GetAuths(new[] { "bearerAuth" }));
        builder.AddJsonBody(req.Data, "application/json");
        return await builder.SendAsyncJsonRes<List<Types.Policydata>>();
    }
}
