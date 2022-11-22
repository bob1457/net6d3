using BubbberDinner.Domain.Common.Models;
using BubbberDinner.Domain.Host.ValueObjects;
using BubbberDinner.Domain.Menu.ValueObjects;
using bubberDineer.Domain.Menu.Entities;

namespace BubbberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _menuSections = new();

    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }

    public HostId HostId { get; }

    public IReadOnlyList<MenuSection> MenuSections => _menuSections.AsReadOnly();

    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        DateTime CreationDateTime,
        DateTime UpdateDateTime
    ) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreationDateTime = CreationDateTime;
        UpdateDateTime = UpdateDateTime;
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId)
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

}