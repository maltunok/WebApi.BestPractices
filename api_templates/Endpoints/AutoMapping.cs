using ApiBestPractices.Endpoints.Endpoints.Authors;
using AutoMapper;
using Infrastructure.DomainModels;

namespace ApiBestPractices.Endpoints;

public class AutoMapping : Profile
{
	public AutoMapping()
	{
		CreateMap<CreateAuthorCommand, Author>();
		CreateMap<Author, CreatedAuthorResult>();

		CreateMap<UpdateAuthorCommand, Author>().ReverseMap();
		CreateMap<Author, UpdatedAuthorResult>();

		CreateMap<Author, AuthorListResult>();

		CreateMap<AuthorDto, Author>().ReverseMap();
		CreateMap<Author, PatchedAuthorResult>();
	}
}
