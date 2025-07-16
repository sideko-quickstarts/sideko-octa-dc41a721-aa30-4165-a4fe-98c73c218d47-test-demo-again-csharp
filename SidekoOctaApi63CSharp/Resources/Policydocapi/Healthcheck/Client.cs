namespace SidekoOctaApi63CSharp.Resources.Policydocapi.Healthcheck;

public class Client
{
    private Core.BaseClient baseClient;

    public Client(Core.BaseClient baseClient)
    {
        this.baseClient = baseClient;
    }

    /// <summary>
    /// Check the health of an API
    ///
    /// GET /policydocapi/healthcheck
    /// </summary>
    public async Task<Types.HealthCheckSuccessResponse> List(Core.RequestOptions? reqOpts = null)
    {
        var builder = new Core.RequestBuilder(
            method: HttpMethod.Get,
            baseUrl: this.baseClient.GetBaseUrl(),
            path: "/policydocapi/healthcheck",
            timeout: this.baseClient.Timeout,
            opts: reqOpts
        );
        await builder.AddAuths(this.baseClient.GetAuths(new[] { "bearerAuth" }));
        return await builder.SendAsyncJsonRes<Types.HealthCheckSuccessResponse>();
    }
}
