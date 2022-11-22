using BubbberDinner.Domain.Common.Models;
using BubbberDinner.Domain.Menu.ValueObjects;

namespace bubberDineer.Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    private readonly List<MenuItem> _items = new();

    public string Name { get; }
    public string Description { get; }

    private MenuItem(MenuItemId menuItemId, string name, string description)
        : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(
        string name,
        string description
        )
    {
        return new MenuItem(
            MenuItemId.CreateUnique(),
            name,
            description
            );
    }
}