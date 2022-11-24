using BubbberDinner.Domain.Common.Models;
using BubbberDinner.Domain.Dinner.ValueObjects;
using BubbberDinner.Domain.Guest.ValueObjects;
using BubbberDinner.Domain.Host.ValueObjects;

namespace BubbberDinner.Domain.Guest.Entities;

public sealed class Rating : Entity<RatingId>
{
    public HostId HostId { get; set; }
    public DinnerId DinnerId { get; set; }
    public float RatingValue { get; set; }
    public DateTime CreationDateTime { get; }
    public DateTime UpdateDateTime { get; }

    private Rating(
        RatingId ratingId,
        HostId hostId,
        DinnerId dinnerId,
        float ratingValue,
        DateTime creationDateTime,
        DateTime updateDateTime

    ) : base(ratingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        RatingValue = ratingValue;
        CreationDateTime = creationDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static Rating Create(
        HostId hostId,
        DinnerId dinnerId,
        float ratingValue,
        DateTime creationDateTime,
        DateTime updateDateTime
    )
    {
        return new(
            RatingId.CreateUnique(),
            hostId,
            dinnerId,
            ratingValue,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}

