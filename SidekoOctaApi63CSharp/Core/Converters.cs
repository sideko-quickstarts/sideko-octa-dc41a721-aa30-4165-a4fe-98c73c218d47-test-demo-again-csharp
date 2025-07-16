namespace SidekoOctaApi63CSharp.Core;

using NJ = Newtonsoft.Json;

public class PatchJsonConverter<T> : NJ.JsonConverter<Patch<T>>
{
    public override void WriteJson(
        NJ.JsonWriter writer,
        Patch<T>? value,
        NJ.JsonSerializer serializer
    )
    {
        if (value == null || value.IsUndefined())
        {
            // Omit writing the property altogether
            return;
        }
        else if (value.IsNull())
        {
            writer.WriteNull();
        }
        else
        {
            serializer.Serialize(writer, value.Value);
        }
    }

    public override Patch<T>? ReadJson(
        NJ.JsonReader reader,
        Type objectType,
        Patch<T>? existingValue,
        bool hasExistingValue,
        NJ.JsonSerializer serializer
    )
    {
        if (reader.TokenType == NJ.JsonToken.Null)
        {
            return Patch<T>.Null();
        }

        var token = NJ.Linq.JToken.Load(reader);
        if (token.Type == NJ.Linq.JTokenType.Null)
            return Patch<T>.Null();

        var value = token.ToObject<T>(serializer);
        return Patch<T>.FromValue(value!);
    }

    public override bool CanWrite => true;
    public override bool CanRead => true;
}

public abstract class Union
{
    public abstract object? GetValue();
}
