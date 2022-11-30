using BubbberDinner.Domain.Menu;

namespace BubbberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}