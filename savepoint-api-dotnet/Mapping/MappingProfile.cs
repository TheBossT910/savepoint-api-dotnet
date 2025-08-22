//using System;
using AutoMapper;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Dtos;
namespace savepoint_api_dotnet.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Game, GameDto>();
			CreateMap<Developer, DeveloperDto>();
			CreateMap<Genre, GenreDto>();
			CreateMap<Image, ImageDto>();
			CreateMap<Video, VideoDto>();
		}
	}
}
