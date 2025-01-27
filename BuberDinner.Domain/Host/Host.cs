using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> menuIds = new();
    private readonly List<DinnerId> dinnerIds = new();
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public UserId UserId{ get; }
    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }
    public IReadOnlyList<MenuId> MenuIds => menuIds;
    public IReadOnlyList<DinnerId> DinnerIds => dinnerIds;

    private Host(HostId hostId, string firstName, string lastName, string profileImage, float averageRating, UserId userId, DateTime createdOn, DateTime modifiedOn) : base(hostId){
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    } 

    public static Host Create(string firstName, string lastName, string profileImage, float averageRating, UserId userId){
        return new Host(HostId.CreateUnique(), firstName, lastName, profileImage, averageRating, userId, DateTime.UtcNow,DateTime.UtcNow);
    }
}