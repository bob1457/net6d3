using BubbberDinner.Application.Menus.Commands.CreateMenu;
using BubbberDinner.Contracts.Menus;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BubbberDinner.Api.Controllers;

[Route("hosts/{hostId}/menu")]
public class MenuController : ApiController
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;

    public MenuController(ISender mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResult = await _mediatr.Send(command);



        return createMenuResult.Match(
            menu => Ok(_mapper.Map<CreateMenuResponse>(menu)),
            error => Problem(error)
        );
    }
}