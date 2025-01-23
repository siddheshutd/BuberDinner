using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public class MenuItem : Entity<MenuItemId>
{
    public string Name { get;}
    public string Description { get;}
    public float Price { get;}

    private MenuItem(MenuItemId menuItemId, string name, string description, float price)
     : base(menuItemId) 
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public static MenuItem Create(string name, string description, float price){
        return new MenuItem(MenuItemId.CreateUnique(), name, description,price);
    }
}