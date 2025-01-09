using BuberDinner.Application.common.Errors;
using FluentResults;
using MediatR;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository){
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public async Task<Result<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if(_userRepository.GetUserByEmail(request.Email) is not null){
            return Result.Fail(new DuplicateEmailError());
        }
        var user = new User(){ Email = request.Email, Password = request.Password , FirstName = request.FirstName, LastName = request.LastName };
        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user);
        return Result.Ok(new AuthenticationResult(user, token)) ;
    }
}