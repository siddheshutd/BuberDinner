using BuberDinner.Contracts.Authentication;
using Mapster;

public class AuthenticationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();    
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map( dest => dest, src => src.User);
    }
}