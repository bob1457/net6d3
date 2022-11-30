using BubbberDinner.Application.Common.Interfaces.Persistence;
using BubbberDinner.Domain.Menu;

namespace BubbberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menu = new();
    public void Add(Menu menu)
    {
        _menu.Add(menu);
    }
}