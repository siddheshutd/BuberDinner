
public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}