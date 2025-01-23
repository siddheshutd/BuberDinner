using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Host.ValueObjects;

public class HostId : ValueObject
{
    
    public Guid Value { get; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private HostId(Guid value){
        Value = value;
    }

    public static HostId CreateUnique(){
        return new(Guid.NewGuid());
    }
}
