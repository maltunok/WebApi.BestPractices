using Ardalis.Result;
using Infrastructure.DomainModels;
using Infrastructure.Security;

namespace Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenFactory _tokenFactory;

        public AuthenticationService(IAsyncRepository<User> userRepository, IPasswordHasher passwordHasher, ITokenFactory tokenFactory)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenFactory = tokenFactory;
        }

        public async Task<Result<AccessToken>> CreateAccessTokenAsync(string email, string password, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordHasher.HashPassowrd(password);

            var users = await _userRepository.ListAllAsync(cancellationToken);

            var user = (await _userRepository.ListByExpressionAsync(x => x.Email == email, cancellationToken)).FirstOrDefault();

            if (user is null || _passwordHasher.PasswordMatches(password, hashedPassword))
                return Result.NotFound();

            return _tokenFactory.CreateAccessToken(user);
        }
    }
}
