using BuberDinner.Domain.Menu;
using FluentResults;
using MediatR;

namespace BuberDinner.Application.Menu.Commands.CreateMenu;

public record CreateMenuCommand(
    string Name,
    string Description,
    List<MenuSectionCommand> Sections
) : IRequest<Result<Domain.Menu.Menu>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items
);

public record MenuItemCommand(
    string Name,
    string Description,
    float Price
);