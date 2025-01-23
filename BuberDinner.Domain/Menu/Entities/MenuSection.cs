using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> menuItems = new();
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<MenuItem> Items => menuItems.AsReadOnly();

    public static MenuSection Create(string name, string description){
        return new MenuSection(MenuSectionId.CreateUnique(), name, description);
    }
    
    private MenuSection(MenuSectionId menuSectionId, string name, string description) : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }
}