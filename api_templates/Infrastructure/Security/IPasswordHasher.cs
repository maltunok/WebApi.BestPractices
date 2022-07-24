namespace Infrastructure.Security
{
    public interface IPasswordHasher
    {
        string HashPassowrd(string password);
        bool PasswordMatches(string providedPassword, string passwordHash);
    }
}
