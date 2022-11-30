using BubberDinner.Domain.Common.Models;

namespace BubbberDinner.Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique() => new(Guid.NewGuid());
    // public static HostId Create(string value)
    // { 
    //     return Guid.Parse(value);
    // }

    // Guid value = Guid.Parse("00000000");

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}