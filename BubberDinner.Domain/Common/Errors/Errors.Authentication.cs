using ErrorOr;

namespace BubberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static partial class Authenticaiton
    {
        public static Error InvalidaCredential => Error.Validation(
                code: "Auth: Invalid Credential", 
                description: "Invalid Credentials"
            );
    }
}