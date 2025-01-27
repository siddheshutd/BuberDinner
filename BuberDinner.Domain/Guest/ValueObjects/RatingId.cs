using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;

public class RatingId : ValueObject
{
    public Guid Value { get; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private RatingId(Guid value){
        Value = value;
    }

    public static RatingId CreateUnique(){
        return new(Guid.NewGuid());
    }
}