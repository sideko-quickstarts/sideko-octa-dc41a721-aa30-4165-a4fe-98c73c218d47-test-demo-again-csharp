namespace SidekoOctaApi63CSharp.Resources.Policydocapi.V2.Policydata;

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
    /// POST /policydocapi/v2/policydata
    /// </summary>
    public async Task<Types.ResponsePayload> Create(Core.RequestOptions? reqOpts = null)
    {
        return await Create(new CreateRequest(), reqOpts);
    }

    /// <summary>
    /// Get policy data and documents
    ///
    /// POST /policydocapi/v2/policydata
    /// </summary>
    public async Task<Types.ResponsePayload> Create(
        CreateRequest req,
        Core.RequestOptions? reqOpts = null
    )
    {
        var builder = new Core.RequestBuilder(
            method: HttpMethod.Post,
            baseUrl: this.baseClient.GetBaseUrl(),
            path: "/policydocapi/v2/policydata",
            timeout: this.baseClient.Timeout,
            opts: reqOpts
        );
        await builder.AddAuths(this.baseClient.GetAuths(new[] { "bearerAuth" }));
        builder.AddJsonBody(req.Data, "application/json");
        return await builder.SendAsyncJsonRes<Types.ResponsePayload>();
    }
}
