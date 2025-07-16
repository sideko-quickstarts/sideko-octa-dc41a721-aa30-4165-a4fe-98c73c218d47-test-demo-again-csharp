namespace SidekoOctaApi63CSharp.Core;

public class Patch<T>
{
    public enum State
    {
        Undefined,
        Null,
        Value,
    }

    public T? Value { get; private set; }

    private State _state;

    private Patch(State state, T? value = default)
    {
        this._state = state;
        this.Value = value;
    }

    public static Patch<T> Undefined() => new Patch<T>(State.Undefined);

    public static Patch<T> Null() => new Patch<T>(State.Null);

    public static Patch<T> FromValue(T value) => new Patch<T>(State.Value, value);

    public void SetUndefined()
    {
        this.Value = default;
        this._state = State.Undefined;
    }

    public void SetNull()
    {
        this.Value = default;
        this._state = State.Null;
    }

    public void SetValue(T value)
    {
        this.Value = value;
        this._state = State.Value;
    }

    public bool IsUndefined()
    {
        return this._state == State.Undefined;
    }

    public bool IsNull()
    {
        return this._state == State.Null;
    }

    public static bool IsPatchUndefined(object value)
    {
        var type = value.GetType();
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Patch<>))
        {
            var method = type.GetMethod("IsUndefined", Type.EmptyTypes);
            if (method != null && method.ReturnType == typeof(bool))
            {
                var isUndefined = (bool?)method.Invoke(value, null);
                if (isUndefined ?? false)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public override string ToString()
    {
        return this._state switch
        {
            State.Undefined => "[undefined]",
            State.Null => "null",
            State.Value => this.Value?.ToString() ?? "null",
            _ => "unknown",
        };
    }
}
