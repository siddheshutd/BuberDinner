namespace BuberDinner.Application.common.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}