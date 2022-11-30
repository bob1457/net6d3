using BubbberDinner.Domain.Menu;

using ErrorOr;

using MediatR;

namespace BubbberDinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections
) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuSItemCommand> Items
);

public record MenuSItemCommand(
    string Name,
    string Description
);