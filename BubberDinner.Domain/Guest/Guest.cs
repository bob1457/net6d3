using BubbberDinner.Domain.Bill.ValueObjects;
using BubbberDinner.Domain.Common.Models;
using BubbberDinner.Domain.Dinner.ValueObjects;
using BubbberDinner.Domain.Guest.ValueObjects;
using BubbberDinner.Domain.MenuReview.ValueObjects;
using BubberDinner.Domain.User.ValueObjects;

namespace BubbberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewDinnerIds = new();


    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public UserId UserId { get; }

    public DateTime CreationDateTime { get; }
    public DateTime UpdateDateTime { get; }

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId,
        DateTime creationDateTime,
        DateTime updateDateTime
    ) : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreationDateTime = creationDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId,
        DateTime creationDateTime,
        DateTime updateDateTime
    )
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }


}