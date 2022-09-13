using System.Reflection.Metadata;
using BubberDinner.Domain.Entities;

namespace BubbberDinner.Application.Common.interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}