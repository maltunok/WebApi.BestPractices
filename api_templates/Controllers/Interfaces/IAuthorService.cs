using Controllers.ApiModels;

namespace Controllers.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDto> CreateAndSave(AuthorDto newAuthor, CancellationToken cancellationToken);
    }
}
