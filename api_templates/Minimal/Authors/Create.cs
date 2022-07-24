﻿using Infrastructure.DomainModels;
using MinimalApi.Endpoint;
using System.ComponentModel.DataAnnotations;

namespace Minimal.Authors
{
    public class Create : IEndpoint<IResult, CreateAuthorRequest>
    {
        private IAsyncRepository<Author> _authorRepository;
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("/authors", async (CreateAuthorRequest request, IAsyncRepository<Author> authorRepository) =>
            {
                _authorRepository = authorRepository;
                return await HandleAsync(request);
            })  .Produces<AuthorCreatedResponse>()
                .WithTags("AuthorsApi");
        }

        public async Task<IResult> HandleAsync(CreateAuthorRequest request)
        {
            var author = new Author
            {
                Name = request.Name,
                TwitterAlias = request.TwitterAlias,
            };

            await _authorRepository.AddAsync(author, new CancellationToken());
            var response = new AuthorCreatedResponse(author.Id, author.Name, author.TwitterAlias, author.PluralsightUrl);
            return Results.Created($"/authors/{author.Id}", response);
        }
    }

    public record CreateAuthorRequest([Required]string Name, string TwitterAlias);
    public record AuthorCreatedResponse(int Id, string Name, string TwitterAlias, string PluralsightUr);
}
