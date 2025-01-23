using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuSectionId : ValueObject
{
    public Guid Value { get; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private MenuSectionId(Guid value){
        Value = value;
    }

    public static MenuSectionId CreateUnique(){
        return new(Guid.NewGuid());
    }
}