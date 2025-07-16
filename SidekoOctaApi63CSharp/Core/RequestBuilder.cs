namespace SidekoOctaApi63CSharp.Core;

using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using UrlParams = Dictionary<string, List<string>>;

public class RequestOptions
{
    /// <summary>
    /// Define additional custom headers to be added to the request
    /// </summary>
    public Dictionary<string, string>? AdditionalHeaders { get; set; }

    /// <summary>
    /// Define additional custom query params to be added to the request
    /// </summary>
    public Dictionary<string, string>? AdditionalQueryParams { get; set; }

    /// <summary>
    /// Define a custom timeout (in seconds)
    /// </summary>
    public double? Timeout { get; set; }
}

public class RequestBuilder
{
    private HttpMethod method;
    private string baseUrl;
    private string path;
    private double? timeout;
    private UrlParams queries;
    private List<(string, string)> headers;
    private List<(string, string)> cookies;
    private HttpContent? content;

    public RequestBuilder(
        HttpMethod method,
        string baseUrl,
        string path,
        double? timeout = null,
        RequestOptions? opts = null
    )
    {
        this.method = method;
        this.baseUrl = baseUrl;
        this.path = path;
        this.headers = new() { ("x-sideko-sdk-language", "C#") };
        this.queries = new();
        this.cookies = new();
        this.timeout = opts?.Timeout ?? timeout;

        if (opts?.AdditionalHeaders != null)
        {
            foreach (var (name, val) in opts.AdditionalHeaders)
            {
                this.AddHeader(name, val);
            }
        }
        if (opts?.AdditionalQueryParams != null)
        {
            foreach (var (name, val) in opts.AdditionalQueryParams)
            {
                this.AddQuery(name, val);
            }
        }
    }

    public async Task AddAuths(List<AuthProvider> providers)
    {
        foreach (var provider in providers)
        {
            await provider.Apply(this);
        }
    }

    public void AddHeader(string name, object? value)
    {
        if (value == null || Patch<object>.IsPatchUndefined(value))
            return;

        this.headers.Add((name, CoreUtils.JsonStringify(value)));
    }

    public void AddCookie(string name, object? value)
    {
        if (value == null)
            return;

        this.cookies.Add((name, CoreUtils.JsonStringify(value)));
    }

    public void AddQuery(string name, object? value, string style = "form", bool explode = true)
    {
        if (value == null || Patch<object>.IsPatchUndefined(value))
            return;

        UrlEncoder.EncodeUrlParam(this.queries, name, value, style, explode);
    }

    public void AddJsonBody(object? body, string contentType)
    {
        if (body == null || Patch<object>.IsPatchUndefined(body))
            return;

        var jsonString = JsonConvert.SerializeObject(body);
        this.content = new StringContent(jsonString, Encoding.UTF8, contentType);
    }

    public void AddTextBody(string? body, string contentType)
    {
        if (body == null)
            return;
        this.content = new StringContent(body, Encoding.UTF8, contentType);
    }

    public void AddBinaryBody(UploadFile? body)
    {
        if (body == null)
            return;
        this.content = new ByteArrayContent(body.Content);
        this.content.Headers.ContentType = new MediaTypeHeaderValue(body.ContentType);
    }

    public void AddMultipartBody(MultipartFormDataContent form)
    {
        if (form == null)
            return;

        this.content = form;
    }

    public void AddFormUrlBody(
        object? body,
        Dictionary<string, string> style,
        Dictionary<string, bool> explode
    )
    {
        if (body == null)
        {
            return;
        }
        else if (body is Dictionary<string, object> mapVal)
        {
            var formParams = new UrlParams();

            foreach (var (key, val) in mapVal)
            {
                var keyStyle = style.GetValueOrDefault(key, "form");
                var keyExplode = explode.GetValueOrDefault(key, keyStyle == "form");
                UrlEncoder.EncodeUrlParam(formParams, key, val, keyStyle, keyExplode);
            }

            var formData = UrlEncoder.Build(formParams);
            this.content = new StringContent(
                formData,
                Encoding.UTF8,
                "application/x-www-form-urlencoded"
            );
        }
        else if (body is Union union)
        {
            AddFormUrlBody(union.GetValue(), style, explode);
        }
        else if (CoreUtils.IsSerDeClass(body))
        {
            AddFormUrlBody(CoreUtils.ConvertToMap(body), style, explode);
        }
        else
        {
            throw new InvalidOperationException(
                "x-www-form-urlencoded data must be a class at the top level"
            );
        }
    }

    private Uri BuildUrl()
    {
        var query = UrlEncoder.Build(this.queries);
        var pathWithQuery = query.Length > 0 ? $"{this.path}?{query}" : this.path;

        return new Uri(
            $"{this.baseUrl.TrimEnd('/')}/{pathWithQuery.TrimStart('/')}".TrimEnd('/'),
            UriKind.Absolute
        );
    }

    public async Task<HttpResponseMessage> SendAsync()
    {
        var request = new HttpRequestMessage(method, this.BuildUrl());

        // add headers
        foreach (var (name, val) in this.headers)
        {
            request.Headers.Add(name, val);
        }

        // add cookies
        var cookieContainer = new CookieContainer();
        foreach (var (cookieName, cookieVal) in this.cookies)
        {
            cookieContainer.Add(new Uri(this.baseUrl), new Cookie(cookieName, cookieVal));
        }

        // add body
        if (this.content != null)
        {
            request.Content = this.content;
        }

        var client = new HttpClient(new HttpClientHandler { CookieContainer = cookieContainer });

        if (this.timeout != null)
        {
            client.Timeout = TimeSpan.FromSeconds((double)this.timeout);
        }

        var res = await client.SendAsync(request);
        res.EnsureSuccessStatusCode();

        return res;
    }

    public async Task<T> SendAsyncJsonRes<T>()
    {
        var response = await this.SendAsync();
        var jsonString = await response.Content.ReadAsStringAsync();
        var deserialized = JsonConvert.DeserializeObject<T>(jsonString);

        if (deserialized == null)
        {
            throw new InvalidOperationException(
                "Response JSON could not be deserialized to the specified type."
            );
        }

        return deserialized;
    }

    public async Task<string> SendAsyncTextRes()
    {
        var response = await this.SendAsync();
        return await response.Content.ReadAsStringAsync() ?? "";
    }

    public async Task<BinaryResponse> SendAsyncBinaryRes()
    {
        var response = await this.SendAsync();
        var content = await response.Content.ReadAsByteArrayAsync();
        var contentType =
            response.Content.Headers.ContentType?.ToString() ?? "application/octet-stream";
        var filename = response.Content?.Headers?.ContentDisposition?.FileName;

        return new BinaryResponse(content, contentType, filename, response.Headers);
    }
}
