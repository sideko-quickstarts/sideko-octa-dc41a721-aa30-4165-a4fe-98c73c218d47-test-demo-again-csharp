namespace SidekoOctaApi63CSharp.Core;

using System.IO;
using MimeTypes;

public class UploadFile
{
    public string FileName { get; private set; }
    public string ContentType { get; private set; }
    public byte[] Content { get; private set; }

    // Constructor for file from disk
    public UploadFile(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found", filePath);

        FileName = Path.GetFileName(filePath);
        ContentType = MimeTypeMap.GetMimeType(FileName);
        Content = File.ReadAllBytes(filePath);
    }

    // Constructor for in-memory file
    public UploadFile(string fileName, string contentType, byte[] contentBytes)
    {
        FileName = fileName;
        ContentType = contentType;
        Content = contentBytes;
    }
}
