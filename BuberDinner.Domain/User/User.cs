
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.User.ValueObjects;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; set;} = null!;
    public string LastName { get; set;} = null!;
    public string Email { get; set;} = null!;
    public string Password { get; set;} = null!;
    public DateTime CreatedOn { get; }
    public DateTime ModifiedOn { get; }

    private User(UserId userId, string firstName, string lastName, string email, string password, DateTime createdOn, DateTime modifiedOn) : base(userId){
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public static User Create(string firstName, string lastName, string email, string password){
        return new User(UserId.CreateUnique(), firstName, lastName, email, password, DateTime.UtcNow, DateTime.UtcNow);
    }
}