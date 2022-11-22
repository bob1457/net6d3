using BubberDinner.Domain.Domain.Common.Models;

namespace BubbberDinner.Domain.Bill.ValueObjects;

public sealed class Price : ValueObject
{
    public float Amount { get; set; }
    public string Currency { get; set; }

    public Price(float amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}