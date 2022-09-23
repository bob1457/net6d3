using BubbberDinner.Application.Services.Authenticaiton.Common;
using BubberDinner.Contracts.Authenticaiton;
using Mapster;

namespace BubbberDinner.Api.Common.Mapping;

public class AuthenticaitonMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            // .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.user);
    }
}