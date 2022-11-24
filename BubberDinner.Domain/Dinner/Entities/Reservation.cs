using BubbberDinner.Domain.Bill.ValueObjects;
using BubbberDinner.Domain.Common.Models;
using BubbberDinner.Domain.Dinner.ValueObjects;
using BubbberDinner.Domain.Guest.ValueObjects;

namespace BubbberDinner.Domain.Dinner.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; set; }
    public string ReservationStatus { get; set; }

    public GuestId GuestId { get; set; }
    public BillId BillId { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    public DateTime CreationDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }

    private Reservation(
        ReservationId reservationId,
        int guestCount,
        GuestId guestId,
        BillId billId,
        DateTime arrivalDateTime,
        DateTime creationDateTime,
        DateTime updateDateTime
    ) : base(reservationId)
    {
        GuestCount = guestCount;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreationDateTime = creationDateTime;
        UpdateDateTime = updateDateTime;
    }

}