namespace SidekoOctaApi63CSharp.Core;

using System.Net.Http.Headers;

public class BinaryResponse
{
    /// <summary>
    /// The binary content to be sent in the response.
    /// </summary>
    public byte[] Content { get; }

    /// <summary>
    /// The MIME type of the binary content (e.g. application/pdf, image/png).
    /// </summary>
    public string ContentType { get; }

    /// <summary>
    /// The unprocessed HTTP response headers
    /// </summary>
    public HttpResponseHeaders Headers { get; }

    /// <summary>
    /// The filename of the binary sent by the API extracted from ContentDisposition
    /// </summary>
    public string? FileName { get; }

    public BinaryResponse(
        byte[] content,
        string contentType,
        string? filename,
        HttpResponseHeaders headers
    )
    {
        this.Content = content;
        this.ContentType = contentType;
        this.FileName = filename;
        this.Headers = headers;
    }

    public override string ToString()
    {
        var headersSummary = Headers?.Select(h => $"{h.Key}: {string.Join(", ", h.Value)}").Take(5); // Limit to 5 headers for brevity

        return $"BinaryResponse:\n"
            + $"- ContentType: {ContentType}\n"
            + $"- FileName: {FileName ?? "N/A"}\n"
            + $"- Content Length: {Content?.Length ?? 0} bytes\n"
            + $"- Headers:\n  {(headersSummary != null ? string.Join("\n  ", headersSummary) : "None")}";
    }
}
