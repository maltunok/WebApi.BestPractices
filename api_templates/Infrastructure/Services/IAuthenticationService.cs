using Infrastructure.Security;
using Ardalis.Result;

namespace Infrastructure.Services
{
    public interface IAuthenticationService
    {
        Task<Result<AccessToken>> CreateAccessTokenAsync(string email, string password, CancellationToken cancellationToken);
    }
}
