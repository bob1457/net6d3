using BubbberDinner.Domain.Common.Models;
using BubbberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.User.ValueObjects;
using BubbberDinner.Domain.Menu.ValueObjects;
using BubbberDinner.Domain.Dinner.ValueObjects;

namespace BubberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public UserId UserId { get; }
    public MenuId MenuId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdateDateTime { get; }

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId,
        MenuId menuId,
        DinnerId dinnerId,
        DateTime creationDateTime,
        DateTime updateDateTime
    ) : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        MenuId = menuId;
        DinnerId = dinnerId;
        CreatedDateTime = creationDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static Host Create(string firstName,
                              string lastName,
                              string profileImage,
                              float averageRating,
                              UserId userId,
                              MenuId menuId,
                              DinnerId dinnerId)
    {
        return new(
         HostId.CreateUnique(),
         firstName,
         lastName,
         profileImage,
         averageRating,
         userId,
         menuId,
         dinnerId,
         DateTime.UtcNow,
         DateTime.UtcNow
        );
    }


}