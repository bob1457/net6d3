using BubbberDinner.Domain.Menu;

using MediatR;
using ErrorOr;
using bubberDineer.Domain.Menu.Entities;
using BubberDineer.Domain.Menu.Entities;
using BubbberDinner.Domain.Host.ValueObjects;
using BubbberDinner.Application.Common.Interfaces.Persistence;

namespace BubbberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Create Menu        
        var menu = Menu.Create(
            // request.hostId,
            HostId.Create(request.HostId),
            request.Name,
            request.Description,
            request.Sections.ConvertAll(s =>
                MenuSection.Create(
                    s.Name,
                    s.Description
                    )));


        // Persist Menu
        _menuRepository.Add(menu);


        return menu;


    }
}
