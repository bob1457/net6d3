using BubbberDinner.Application.Menus.Commands.CreateMenu;
using BubbberDinner.Contracts.Menus;
using BubbberDinner.Domain.Menu;

using Mapster;

namespace BubbberDinner.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
        .Map(dest => dest.HostId, src => src.HostId)
        .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, CreateMenuResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.AverageRating, src => src.AverageRating)
        .Map(dest => dest.HostId, src => src.HostId.Value);
        // .Map(dest => dest.DinnerId, src => src.DinnerId.Value);        

    }
}