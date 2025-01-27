using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects;

public class GuestId : ValueObject
{
    public Guid Value { get; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private GuestId(Guid value){
        Value = value;
    }

    public static GuestId CreateUnique(){
        return new(Guid.NewGuid());
    }
}