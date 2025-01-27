using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<Rating> ratings = new();
    private readonly List<DinnerId> upcomingDinnerIds = new();
    private readonly List<DinnerId> pastDinnerIds = new();
    private readonly List<BillId> billIds = new();
    private readonly List<MenuReviewId> menuReviewIds = new();
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public UserId UserId { get; }
    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => upcomingDinnerIds;
    public IReadOnlyList<DinnerId> PastDinnerIds => pastDinnerIds;
    public IReadOnlyList<BillId> BillIds => billIds;
    public IReadOnlyList<MenuReviewId> MenuReviewIds => menuReviewIds;
    public IReadOnlyList<Rating> Ratings => ratings;

    private Guest(GuestId guestId, string firstName, string lastName, string profileImage, float averageRating, UserId userId, DateTime createdOn, DateTime modifiedOn) : base(guestId) 
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public static Guest Create(string firstName, string lastName, string profileImage, float averageRating, UserId userId){
        return new Guest(GuestId.CreateUnique(), firstName, lastName, profileImage, averageRating, userId, DateTime.UtcNow, DateTime.UtcNow);
    }
}
