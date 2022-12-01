using BubbberDinner.Application.Menus.Commands.CreateMenu;

using FluentValidation;

namespace BubbberDinner.Application.Menus.Commands;

public class CreateMenuValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}