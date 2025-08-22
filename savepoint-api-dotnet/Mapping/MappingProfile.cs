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
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.Videos, opt => opt.Ignore())
                .ForMember(dest => dest.Genres, opt => opt.Ignore())
                .ForMember(dest => dest.Developers, opt => opt.Ignore());
            CreateMap<GameCreateDto, Game>()
				.ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.Videos, opt => opt.Ignore())
                .ForMember(dest => dest.Genres, opt => opt.Ignore())
                .ForMember(dest => dest.Developers, opt => opt.Ignore());

            CreateMap<Developer, DeveloperDto>();
			CreateMap<Genre, GenreDto>();
			CreateMap<Image, ImageDto>();
			CreateMap<Video, VideoDto>();
		}
	}
}
