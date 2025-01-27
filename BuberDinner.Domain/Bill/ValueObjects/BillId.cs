using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill.ValueObjects;

public class BillId : ValueObject
{
    public Guid Value { get; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private BillId(Guid value){
        Value = value;
    }

    public static BillId CreateUnique(){
        return new(Guid.NewGuid());
    }
}