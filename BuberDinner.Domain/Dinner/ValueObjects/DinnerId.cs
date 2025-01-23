using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class DinnerId : ValueObject
{
    public Guid Value { get; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private DinnerId(Guid value){
        Value = value;
    }

    public static DinnerId CreateUnique(){
        return new(Guid.NewGuid());
    }
}
