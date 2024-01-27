using System.Text.Json.Serialization;

namespace Dartomat.Core.Domain;

public record Round(Throw Dart1, Throw Dart2, Throw Dart3)
{
    [JsonIgnore]
    public decimal Score => Dart1.Score + Dart2.Score + Dart3.Score;
}

public record Throw(Multiplier multiplier, decimal value)
{
    [JsonIgnore]
    public decimal Score => (int) multiplier * value;

    // Converts a string of Format (S/D/T)XX, where S/D/T is the Multiplier Single/Double/Triple and XX is a value between 0 and 25
    public static Throw FromString(string throwValue) => throwValue switch
    {
        { Length: 3 or 2 } v when v[0] is 'S' && int.TryParse(v, out var parsed) => new (Multiplier.Single, parsed),
        { Length: 3 or 2 } v when v[0] is 'D' && int.TryParse(v, out var parsed) => new (Multiplier.Double, parsed),
        { Length: 3 or 2 } v when v[0] is 'T' && int.TryParse(v, out var parsed) => new (Multiplier.Triple, parsed),
        _ => throw new ArgumentOutOfRangeException(nameof(throwValue))
    };
}

public enum Multiplier
{
    Single = 1,
    Double = 2,
    Triple = 3
}