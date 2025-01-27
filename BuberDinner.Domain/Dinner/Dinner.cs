using BuberDinner.Domain.Bill.Entities;
using BuberDinner.Domain.Common.Enums;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> reservations = new();
    public HostId HostId { get; }
    public MenuId MenuId{ get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }
    public DinnerStatus DinnerStatus{ get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public IReadOnlyList<Reservation> Reservations => reservations;

    private Dinner(DinnerId dinnerId, HostId hostId, MenuId menuId, string name, string description, DateTime createdOn, DateTime modifiedOn, DateTime startTime, DateTime endTime, bool isPublic, int maxGuests, Price price): base(dinnerId)
    {
        HostId = hostId;
        MenuId = menuId;
        Name = name;
        Description = description;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
        StartTime = startTime;
        EndTime = endTime;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
    }

    public static Dinner Create(HostId hostId, MenuId menuId, string name, string description, DateTime startTime, DateTime endTime, bool isPublic, int maxGuests, int price)
    {
        return new(DinnerId.CreateUnique(), hostId, menuId, name, description, DateTime.UtcNow, DateTime.UtcNow, startTime, endTime, isPublic, maxGuests, Price.Create(price));
    }

}
