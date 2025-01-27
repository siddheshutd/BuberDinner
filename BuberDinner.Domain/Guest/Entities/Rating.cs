using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities;

public class Rating : Entity<RatingId>
{
    public HostId HostId{ get; }
    public DinnerId DinnerId{ get; }
    public float RatingScore{ get; }
    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }

    private Rating(RatingId ratingId, HostId hostId, DinnerId dinnerId, float rating, DateTime createdOn, DateTime modifiedOn) : base(ratingId){
        HostId = hostId;
        DinnerId = dinnerId;
        RatingScore = rating;
        CreatedOn = createdOn;  
        ModifiedOn = modifiedOn;
    }

    public static Rating Create(HostId hostId, DinnerId dinnerId, float rating){
        return new Rating(RatingId.CreateUnique(), hostId, dinnerId, rating,DateTime.UtcNow, DateTime.UtcNow);
    }
}
