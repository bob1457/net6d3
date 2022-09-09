namespace BubbberDinner.Application.Common.interfaces.Authenticaiton;

public interface IJwtTokenGenerator 
{
    string GenerateToken(Guid id, string firstName, string lastName);
}