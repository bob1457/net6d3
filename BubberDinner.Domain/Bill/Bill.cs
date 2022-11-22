using BubbberDinner.Domain.Bill.ValueObjects;
using BubbberDinner.Domain.Common.Models;
using BubbberDinner.Domain.Host.ValueObjects;

namespace BubbberDinner.Domain.Bill;

public sealed class Bill : AggregateRoot<BillId>
{
    public Price Price { get; set; }
    public HostId HostId { get; set; }
    public GuestId GuestId { get; set; }
    public DinnerId DinnerId { get; set; }

    private Bill(
        BillId billId,
        HostId hostId,
        GuestId guestId,
        DinnerId dinnerId,
        Price price,
        DateTime CreationDateTime,
        DateTime UpdateDateTime
        ) : base(billId)
    {
        HostId = hostId;
        GuestId = guestId;
        DinnerId = dinnerId;
        Price = price;
        CreationDateTime = CreationDateTime;
        UpdateDateTime = UpdateDateTime;

    }

}