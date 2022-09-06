namespace BubberDinner.Contracts.Authenticaiton;

public record LoginRequest(    
    string Email,
    string Password
);