using BubbberDinner.Domain.Common.Models;
using BubberDinner.Domain.User.ValueObjects;

namespace BubbberDinner.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    public DateTime CreationDateTime { get; }
    public DateTime UpdateDateTime { get; }

    private User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime creationDateTime,
        DateTime updateDateTime) : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreationDateTime = creationDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static User Create(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime creationDateTime,
        DateTime updateDateTime
    )
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            creationDateTime,
            updateDateTime
        );
    }
}