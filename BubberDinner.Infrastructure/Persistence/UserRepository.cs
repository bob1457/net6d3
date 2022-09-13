using BubbberDinner.Application.Common.interfaces.Persistence;
using BubberDinner.Domain.Entities;

namespace BubbberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new(); // will be replaced by dbcontext with EF core
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}