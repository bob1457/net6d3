using BubbberDinner.Domain.Bill.ValueObjects;
using BubbberDinner.Domain.Common.Models;
using BubbberDinner.Domain.Dinner.ValueObjects;
using BubbberDinner.Domain.Host.ValueObjects;

namespace BubbberDinner.Domain.Bill;

public sealed class Bill : AggregateRoot<BillId>
{
    public Price Price { get; set; }
    public HostId HostId { get; set; }
    public GuestId GuestId { get; set; }
    public DinnerId DinnerId { get; set; }

    public DateTime CreationDateTime { get; }
    public DateTime UpdateDateTime { get; }

    private Bill(
        BillId billId,
        HostId hostId,
        GuestId guestId,
        DinnerId dinnerId,
        Price price,
        DateTime creationDateTime,
        DateTime updateDateTime
        ) : base(billId)
    {
        HostId = hostId;
        GuestId = guestId;
        DinnerId = dinnerId;
        Price = price;
        CreationDateTime = creationDateTime;
        UpdateDateTime = updateDateTime;

    }

    public static Bill Create(
        HostId hostId,
        GuestId guestId,
        DinnerId dinnerId,
        Price price
    )
    {
        return new(
            BillId.CreateUnique(),
            hostId,
            guestId,
            dinnerId,
            price,
            DateTime.UtcNow,
            DateTime.UtcNow
        );

    }

}