using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> sections = new();
    private readonly List<DinnerId> dinnerIds = new();
    private readonly List<MenuReviewId> menuReviewIds = new();
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }
    public HostId HostId { get; }
    public IReadOnlyList<MenuSection> Sections => sections;
    public IReadOnlyList<DinnerId> DinnerIds => dinnerIds;
    public IReadOnlyList<MenuReviewId> MenuReviewIds => menuReviewIds;

    private Menu(MenuId menuId, string name, string description, float averageRating, DateTime createdOn, DateTime modifiedOn, HostId hostId) : base(menuId){
        Name = name;
        Description = description;
        AverageRating = averageRating;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
        HostId = hostId;
    }

    public static Menu Create(string name, string description, float averageRating, HostId hostId){
        return new(MenuId.CreateUnique(), name, description, averageRating, DateTime.UtcNow, DateTime.UtcNow, hostId);
    }
}