using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.User.ValueObjects;

public class UserId : ValueObject
{
    public Guid Value { get; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private UserId(Guid value){
        Value = value;
    }

    public static UserId CreateUnique(){
        return new(Guid.NewGuid());
    }
}