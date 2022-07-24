using Infrastructure.DomainModels;

namespace Infrastructure.Security
{
    public interface ITokenFactory
    {
        AccessToken CreateAccessToken(User user);
    }
}
