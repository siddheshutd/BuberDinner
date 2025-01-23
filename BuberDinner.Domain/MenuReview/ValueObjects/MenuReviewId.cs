using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReview.ValueObjects;

public class MenuReviewId : ValueObject
{
    public Guid Value { get; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private MenuReviewId(Guid value){
        Value = value;
    }

    public static MenuReviewId CreateUnique(){
        return new(Guid.NewGuid());
    }
}
