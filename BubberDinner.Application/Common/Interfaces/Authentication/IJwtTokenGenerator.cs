using BubberDinner.Domain.Entities;

namespace BubbberDinner.Application.Common.interfaces.Authenticaiton;

public interface IJwtTokenGenerator 
{
    string GenerateToken(User user);
}