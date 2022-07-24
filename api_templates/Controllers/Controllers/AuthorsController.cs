using Controllers.ApiModels;
using Infrastructure.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    [ApiController]
    [Route("Authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly IAsyncRepository<Author> _authorRepository;

        public AuthorsController(ILogger<AuthorsController> logger, IAsyncRepository<Author> authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        [HttpGet]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
        // NOTE: VaryByQueryKeys requires adding Response Cache Middleware (and services)
        public async Task<ActionResult<AuthorDto>> Index ( CancellationToken cancellationToken)
        {
            _logger.LogInformation("Returning Author List from /Authors.");

            var authors = await _authorRepository.ListAllAsync(cancellationToken);

            var responseModel = authors.Select(x => new AuthorDto(x.Id, x.Name, x.TwitterAlias ?? "")).ToList();

            return Ok(responseModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type =typeof(AuthorDto))]
        public async Task<ActionResult<AuthorDto>> Create(AuthorDto newAuthor, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = newAuthor.Name,
                TwitterAlias = newAuthor.TwitterAlias,
            };

            await _authorRepository.AddAsync(author, cancellationToken);

            var authotDto = new AuthorDto (author.Id, author.Name, author.TwitterAlias);

            return Created($"authors/{author.Id}", authotDto);
        }
    }
}
