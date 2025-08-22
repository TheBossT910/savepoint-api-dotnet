//using System;
using AutoMapper;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Dtos;
using savepoint_api_dotnet.Dtos.Games;
namespace savepoint_api_dotnet.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Game, GameDto>();

			CreateMap<GameUpdateDto, Game>()
				.ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
				.ForMember(dest => dest.Videos, opt => opt.MapFrom(src => src.Videos))
                .ForMember(dest => dest.Developers, opt => opt.MapFrom<DeveloperUpdateResolver>())
				.ForMember(dest => dest.Genres, opt => opt.MapFrom<GenreUpdateResolver>());

			CreateMap<GameCreateDto, Game>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
				.ForMember(dest => dest.Videos, opt => opt.MapFrom(src => src.Videos))
				.ForMember(dest => dest.Developers, opt => opt.MapFrom<DeveloperCreateResolver>())
				.ForMember(dest => dest.Genres, opt => opt.MapFrom<GenreCreateResolver>());

			CreateMap<Developer, DeveloperDto>();

			CreateMap<Genre, GenreDto>();

			CreateMap<Image, ImageDto>()
				.ReverseMap();

			CreateMap<Video, VideoDto>()
				.ReverseMap();
		}
	}
}
