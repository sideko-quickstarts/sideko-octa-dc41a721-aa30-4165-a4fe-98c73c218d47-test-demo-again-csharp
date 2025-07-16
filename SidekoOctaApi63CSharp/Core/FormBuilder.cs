namespace SidekoOctaApi63CSharp.Core;

using System.Collections;

public class FormBuilder
{
    public MultipartFormDataContent Form { get; }

    public FormBuilder()
    {
        this.Form = new();
    }

    public void AddPart(string name, object? value)
    {
        if (value == null)
        {
            return;
        }
        else if (CoreUtils.IsArrayOrList(value))
        {
            IEnumerable enumerable = (IEnumerable)value;
            foreach (var item in enumerable)
            {
                AddPart(name, item);
            }
        }
        else if (value is Core.Union union)
        {
            AddPart(name, union.GetValue());
        }
        else if (value is UploadFile uploadFile)
        {
            AddFilePart(name, uploadFile);
        }
        else
        {
            AddTextPart(name, value);
        }
    }

    public void AddFilePart(string name, UploadFile file)
    {
        var fileContent = new ByteArrayContent(file.Content, 0, file.Content.Length);
        this.Form.Add(fileContent, name, file.FileName);
    }

    public void AddTextPart(string name, object value)
    {
        this.Form.Add(new StringContent(CoreUtils.JsonStringify(value)), name);
    }
}
