using Controllers.ApiModels;
using Controllers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
	// SHOW USING A SERVICE INSTEAD OF A REPOSITORY IN ACTION METHOD

	[ApiController]
	[Route("AuthorsUsingService")]
	public class AuthorsUsingServiceController : ControllerBase
	{
		private readonly IAuthorService _authorService;

		public AuthorsUsingServiceController(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		[HttpPost()]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AuthorDto))]
		public async Task<ActionResult<AuthorDto>> Create(AuthorDto newAuthor,
			CancellationToken cancellationToken)
		{
			var createdAuthorDto = _authorService.CreateAndSave(newAuthor, cancellationToken);
			return Created($"authors/{createdAuthorDto.Id}", createdAuthorDto);
		}
	}
}
