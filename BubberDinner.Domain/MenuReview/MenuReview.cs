using BubbberDinner.Domain.Bill.ValueObjects;
using BubbberDinner.Domain.Common.Models;
using BubbberDinner.Domain.Dinner.ValueObjects;
using BubbberDinner.Domain.Guest.ValueObjects;
using BubbberDinner.Domain.Host.ValueObjects;
using BubbberDinner.Domain.Menu.ValueObjects;
using BubbberDinner.Domain.MenuReview.ValueObjects;

namespace BubbberDinner.Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{

    public float Rating { get; }
    public string Comment { get; }

    public HostId HostId { get; }
    public MenuId MenuId { get; }

    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }

    public DateTime CreationDateTime { get; }
    public DateTime UpdateDateTime { get; }

    private MenuReview(
        MenuReviewId menuReviewId,
        float rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime creationDateTime,
        DateTime updateDateTime

    ) : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreationDateTime = creationDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static MenuReview Create(
        float rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime creationDateTime,
        DateTime updateDateTime
    )
    {
        return new(
            MenuReviewId.CreateUnique(),
            rating,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

}