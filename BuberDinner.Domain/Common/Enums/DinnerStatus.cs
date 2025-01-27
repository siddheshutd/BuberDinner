using System.Runtime.Serialization;

namespace BuberDinner.Domain.Common.Enums;

public enum DinnerStatus
{
    [EnumMember]
    Upcoming,
    [EnumMember]
    InProgress,
    [EnumMember]
    Ended
}
