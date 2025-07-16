namespace SidekoOctaApi63CSharp.Core;

public class BaseClient
{
    private static readonly string DEFAULT_SERVICE_NAME = "__default_service__";
    private Dictionary<string, string> baseUrl;
    private Dictionary<string, AuthProvider> auths;
    public double? Timeout { get; set; }

    public BaseClient(string baseUrl, double? timeout = null)
        : this(new Dictionary<string, string> { { DEFAULT_SERVICE_NAME, baseUrl } }, timeout) { }

    public BaseClient(Dictionary<string, string> baseUrl, double? timeout = null)
    {
        this.baseUrl = baseUrl;
        this.Timeout = timeout;
        this.auths = new();
    }

    public void RegisterAuth(string name, AuthProvider provider)
    {
        this.auths.Add(name, provider);
    }

    public List<AuthProvider> GetAuths(IEnumerable<string> names)
    {
        var providers = new List<AuthProvider>();

        foreach (var name in names)
        {
            if (this.auths.ContainsKey(name))
            {
                providers.Add(this.auths[name]);
            }
        }

        return providers;
    }

    public string GetBaseUrl()
    {
        return this.GetBaseUrl(DEFAULT_SERVICE_NAME);
    }

    public string GetBaseUrl(string serviceName)
    {
        return this.baseUrl.ContainsKey(serviceName) ? this.baseUrl[serviceName] : "";
    }
}
