namespace SidekoOctaApi63CSharp.Resources.Policydocapi.V2.PolicyDocument;

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
    /// GET /policydocapi/v2/policy-document/{documentId}/{setType}
    /// </summary>
    public async Task<string> Get(GetRequest req, Core.RequestOptions? reqOpts = null)
    {
        var builder = new Core.RequestBuilder(
            method: HttpMethod.Get,
            baseUrl: this.baseClient.GetBaseUrl(),
            path: $"/policydocapi/v2/policy-document/{Core.CoreUtils.JsonStringify(req.DocumentId)}/{Core.CoreUtils.JsonStringify(req.SetType)}",
            timeout: this.baseClient.Timeout,
            opts: reqOpts
        );
        await builder.AddAuths(this.baseClient.GetAuths(new[] { "bearerAuth" }));
        return await builder.SendAsyncJsonRes<string>();
    }
}
