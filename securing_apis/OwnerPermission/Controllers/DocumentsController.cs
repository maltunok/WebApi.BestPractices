using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OwnerPermission.Data;
using OwnerPermission.Models;
using OwnerPermission.Services;

namespace OwnerPermission.Controllers
{
	/// <summary>
	/// See: https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/security/authorization/resourcebased/samples/3_0/ResourceBasedAuthApp2
	/// </summary>
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class DocumentController : ControllerBase
	{
		private readonly IAuthorizationService _authorizationService;
		private readonly IDocumentRepository _documentRepository;
		private readonly ILogger<DocumentController> _logger;

		public DocumentController(IAuthorizationService authorizationService,
															IDocumentRepository documentRepository,
															ILogger<DocumentController> logger)
		{
			_authorizationService = authorizationService;
			_documentRepository = documentRepository;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> GetById(int documentId)
		{
			_logger.LogInformation($"Attempting to view documentId {documentId} as {User.Identity!.Name}");
			Document document = _documentRepository.Find(documentId);

			if (document == null)
			{
				return new NotFoundResult();
			}

			var userIsAuthorized = (await _authorizationService
					.AuthorizeAsync(User, document, Operations.Read)).Succeeded;

			if (userIsAuthorized)
			{
				return Ok(document);
			}
			else
			{
				return Unauthorized();
			}
		}
	}
}
