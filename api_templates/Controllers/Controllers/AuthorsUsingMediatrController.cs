using Controllers.ApiModels;
using Controllers.Handlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    [ApiController]
    [Route("AuthorsUsingMediatr")]
    public class AuthorsUsingMediatrController : ControllerBase
    {
        public IMediator Mediator { get; }
        public AuthorsUsingMediatrController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AuthorDto))]
        public async Task<ActionResult<AuthorDto>> Create(AuthorDto newAuthor, CancellationToken cancellationToken)
        {
            var createAuthorCommand = new CreateAuthorCommand(newAuthor.Name, newAuthor.TwitterAlias);

            var createdAuthotDto = await Mediator.Send(createAuthorCommand, cancellationToken);

            return Created($"authors/{createdAuthotDto.Id}", createdAuthotDto);
        }
    }
}
