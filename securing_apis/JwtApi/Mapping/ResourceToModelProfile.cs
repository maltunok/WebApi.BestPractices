using AutoMapper;
using JwtApi.Core.Models;

namespace JWTAPI.Mapping;

public class ResourceToModelProfile : Profile
{
	public ResourceToModelProfile()
	{
		CreateMap<UserCredentialsResource, User>();
	}
}
