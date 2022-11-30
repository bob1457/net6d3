using BubbberDinner.Domain.Common.Models;
using BubbberDinner.Domain.Host.ValueObjects;
using BubbberDinner.Domain.Menu.ValueObjects;

using bubberDineer.Domain.Menu.Entities;

using BubberDineer.Domain.Menu.Entities;

namespace BubbberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _menuSections = new();

    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }

    public HostId HostId { get; }

    public DateTime CreationDateTime { get; }
    public DateTime UpdateDateTime { get; }

    public IReadOnlyList<MenuSection> MenuSections => _menuSections.AsReadOnly();

    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        DateTime creationDateTime,
        DateTime updateDateTime
    ) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreationDateTime = creationDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        List<MenuSection> menuSections
        )
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

    // public static object Create(Guid guid, string name, string description, List<MenuSection> menuSections)
    // {
    //     throw new NotImplementedException();
    // }
}