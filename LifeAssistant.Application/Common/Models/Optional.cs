namespace LifeAssistant.Application.Common.Models;

/// <summary>
/// Tri-state wrapper that distinguishes "not provided" from "provided null",
/// enabling PATCH handlers to clear optional fields when null is explicitly sent.
/// </summary>
public readonly struct Optional<T>
{
    private readonly T? _value;

    private Optional(T? value, bool hasValue)
    {
        _value = value;
        HasValue = hasValue;
    }

    public T? Value => _value;
    public bool HasValue { get; }

    public static Optional<T> Of(T? value) => new(value, true);

    public static Optional<T> None => new(default, false);

    public static implicit operator Optional<T>(T? value) => Of(value);
}
