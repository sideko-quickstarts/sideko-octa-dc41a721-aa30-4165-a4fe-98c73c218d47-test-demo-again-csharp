namespace SidekoOctaApi63CSharp.Core;

using System.Text;
using System.Text.Json;

public abstract class AuthProvider
{
    public abstract Task Apply(RequestBuilder builder);
    public abstract void SetValue(string? value);
}

class AuthBasic : AuthProvider
{
    private string? username;
    private string? password;

    public AuthBasic(string? username, string? password)
    {
        this.username = username;
        this.password = password;
    }

    public override Task Apply(RequestBuilder builder)
    {
        if (this.username != null || this.password != null)
        {
            string authInfo = Convert.ToBase64String(
                Encoding.UTF8.GetBytes($"{this.username ?? ""}:{this.password ?? ""}")
            );
            builder.AddHeader("Authorization", $"Basic {authInfo}");
        }

        return Task.CompletedTask;
    }

    public override void SetValue(string? value)
    {
        this.username = value;
    }
}

class AuthKey : AuthProvider
{
    private string name;
    private string location;
    private string? value;

    public AuthKey(string name, string location, string? value)
    {
        this.name = name;
        this.location = location;
        this.value = value;
    }

    public override Task Apply(RequestBuilder builder)
    {
        if (this.value == null)
        {
            return Task.CompletedTask;
        }

        if (this.location == "header")
        {
            builder.AddHeader(this.name, this.value);
        }
        else if (this.location == "query")
        {
            builder.AddQuery(this.name, this.value);
        }
        else if (this.location == "cookie")
        {
            builder.AddCookie(this.name, this.value);
        }

        return Task.CompletedTask;
    }

    public override void SetValue(string? value)
    {
        this.value = value;
    }
}

class AuthBearer : AuthProvider
{
    private string? token;

    public AuthBearer(string? token)
    {
        this.token = token;
    }

    public override Task Apply(RequestBuilder builder)
    {
        if (this.token != null)
        {
            builder.AddHeader("Authorization", $"Bearer {this.token}");
        }

        return Task.CompletedTask;
    }

    public override void SetValue(string? value)
    {
        this.token = value;
    }
}

public interface IOAuth2Form
{
    string? GrantType { get; }
    List<string>? Scope { get; }
    string? TokenUrl { get; }

    Dictionary<string, string?> GetFormValues();
}

class OAuth2 : AuthProvider
{
    // OAuth2 provider configuration
    private string baseUrl;
    private string tokenUrl;
    private string accessTokenPointer;
    private string expiresInPointer;
    private string credentialsLocation;
    private string bodyContent;
    private AuthProvider requestMutator;

    // OAuth2 access token request values
    private string? username;
    private string? password;
    private string? clientId;
    private string? clientSecret;
    private string grantType;
    private List<string>? scope;

    // access token retention
    private string? accessToken;
    private DateTime? expiresAt;

    public OAuth2(
        string baseUrl,
        string defaultTokenUrl,
        string accessTokenPointer,
        string expiresInPointer,
        string credentialsLocation,
        string bodyContent,
        AuthProvider requestMutator,
        IOAuth2Form? form
    )
    {
        this.baseUrl = baseUrl;
        this.tokenUrl = form?.TokenUrl ?? defaultTokenUrl;
        this.accessTokenPointer = accessTokenPointer;
        this.expiresInPointer = expiresInPointer;
        this.credentialsLocation = credentialsLocation;
        this.bodyContent = bodyContent;
        this.requestMutator = requestMutator;

        Dictionary<string, string?> formVals = form?.GetFormValues() ?? new();
        string defaultGrantType = formVals.ContainsKey("username")
            ? "password"
            : "client_credentials";

        this.grantType = form?.GrantType ?? defaultGrantType;
        this.scope = form?.Scope;
        formVals.TryGetValue("username", out this.username);
        formVals.TryGetValue("password", out this.password);
        formVals.TryGetValue("client_id", out this.clientId);
        formVals.TryGetValue("client_secret", out this.clientSecret);
    }

    private async Task Refresh()
    {
        // determine base url & token url path
        bool tokenUrlIsRelative = this.tokenUrl.StartsWith('/');
        string baseUrl = tokenUrlIsRelative ? this.baseUrl : this.tokenUrl;
        string path = tokenUrlIsRelative ? this.tokenUrl : "";

        RequestBuilder builder = new RequestBuilder(HttpMethod.Post, baseUrl, path);
        Dictionary<string, string> data = new() { ["grant_type"] = this.grantType };

        // add client credentials as basic authorizaiton header or in request data
        if (this.clientId != null || this.clientSecret != null)
        {
            if (this.credentialsLocation == "basic_authorization_header")
            {
                await builder.AddAuths(
                    new List<AuthProvider> { new AuthBasic(this.clientId, this.clientSecret) }
                );
            }
            else
            {
                if (this.clientId != null)
                {
                    data["client_id"] = this.clientId;
                }
                if (this.clientSecret != null)
                {
                    data["client_secret"] = this.clientSecret;
                }
            }
        }

        // add other request data
        if (this.username != null)
        {
            data["username"] = this.username;
        }
        if (this.password != null)
        {
            data["password"] = this.password;
        }
        if (this.scope != null)
        {
            data["scope"] = string.Join(" ", this.scope);
        }

        // add data to builder
        if (this.bodyContent == "json")
        {
            builder.AddJsonBody(data, "application/json");
        }
        else
        {
            builder.AddFormUrlBody(data, new(), new());
        }

        string resContent = await builder.SendAsyncTextRes();
        JsonDocument json = JsonDocument.Parse(resContent);
        this.accessToken = CoreUtils.GetStringByPointer(json, this.accessTokenPointer);
        int expiresInSecs = CoreUtils.GetIntByPointer(json, this.expiresInPointer) ?? 600;
        this.expiresAt = DateTime.UtcNow.AddSeconds(expiresInSecs);
    }

    public override async Task Apply(RequestBuilder builder)
    {
        if (
            this.clientId == null
            && this.clientSecret == null
            && this.username == null
            && this.password == null
        )
        {
            // auth provider is not configured to make token request
            return;
        }

        bool tokenExpired = this.expiresAt != null && this.expiresAt <= DateTime.UtcNow;
        if (this.accessToken == null || tokenExpired)
        {
            await this.Refresh();
        }

        this.requestMutator.SetValue(this.accessToken);

        await this.requestMutator.Apply(builder);
    }

    public override void SetValue(string? value)
    {
        throw new NotImplementedException("an OAuth2 auth provider cannot be a requestMutator");
    }
}
