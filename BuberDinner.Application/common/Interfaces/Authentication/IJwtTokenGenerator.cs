public interface IJwtTokenGenerator{
    string GenerateToken(User user);
}