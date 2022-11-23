using BubbberDinner.Domain.Bill.ValueObjects;
using BubbberDinner.Domain.Common.Models;
using BubbberDinner.Domain.Dinner.Entities;
using BubbberDinner.Domain.Dinner.ValueObjects;

namespace BubbberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public string Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public string ImgUrl { get; }

    public Price Price { get; }

    public Location Location { get; }

    public DateTime CreationDateTime { get; }
    public DateTime UpdateDateTime { get; }

    public Reservation Reservation { get; }

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        string status,
        bool isPublic,
        int maxGuests,
        string imgUrl,
        Price price,
        Location location,
        Reservation reservation
        ) : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        ImgUrl = imgUrl;
        Price = price;
        Location = location;
        Reservation = reservation;
    }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        string status,
        bool isPublic,
        int maxGuests,
        string imgUrl,
        Price price,
        Location location,
        Reservation reservation)
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            status,
            isPublic,
            maxGuests,
            imgUrl,
            price,
            location,
            reservation

        );
    }

}