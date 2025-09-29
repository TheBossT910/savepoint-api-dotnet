//using System;
using AutoMapper;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Dtos;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Dtos.Stacks;
using savepoint_api_dotnet.Dtos.Lists;
namespace savepoint_api_dotnet.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// Game
			CreateMap<Game, GameDto>();

			CreateMap<GameUpdateDto, Game>()
				.ForMember(dest => dest.Images, opt => opt.MapFrom<ImageUpdateResolver>())
				.ForMember(dest => dest.Videos, opt => opt.MapFrom<VideoUpdateResolver>())
				.ForMember(dest => dest.Developers, opt => opt.MapFrom<DeveloperUpdateResolver>())
				.ForMember(dest => dest.Genres, opt => opt.MapFrom<GenreUpdateResolver>())
                .ForMember(dest => dest.Categories, opt => opt.MapFrom<CategoryUpdateResolver>())
                .ForMember(dest => dest.GameVariations, opt => opt.MapFrom<GameVariationUpdateResolver>())
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom<ReviewUpdateResolver>())
                .ForMember(dest => dest.Platforms, opt => opt.MapFrom<PlatformUpdateResolver>());

            CreateMap<GameCreateDto, Game>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
                .ForMember(dest => dest.Videos, opt => opt.MapFrom(src => src.Videos))
                .ForMember(dest => dest.Developers, opt => opt.MapFrom<DeveloperCreateResolver>())
                .ForMember(dest => dest.Genres, opt => opt.MapFrom<GenreCreateResolver>())
                .ForMember(dest => dest.Categories, opt => opt.MapFrom<CategoryCreateResolver>())
                .ForMember(dest => dest.GameVariations, opt => opt.MapFrom<GameVariationCreateResolver>())
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
                .ForMember(dest => dest.PlayTime, opt => opt.MapFrom(src => src.PlayTime))
                .ForMember(dest => dest.Platforms, opt => opt.MapFrom<PlatformCreateResolver>());

            CreateMap<Developer, DeveloperDto>();

			CreateMap<GameVariation, GameVariationDto>()
				.ForMember(dest => dest.GameIds, opt => opt.MapFrom(src => src.Games != null ? src.Games.ConvertAll(g => g.Id) : new List<Guid>()));

            CreateMap<Genre, GenreDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Image, ImageDto>()
				.ReverseMap();

			CreateMap<Video, VideoDto>()
				.ReverseMap();

			// Stack
			CreateMap<Stack, StackDto>();

			CreateMap<StackUpdateDto, Stack>()
				.ForMember(dest => dest.Games, opt => opt.MapFrom<StackGameUpdateResolver>());

            CreateMap<StackCreateDto, Stack>()
                .ForMember(dest => dest.Games, opt => opt.MapFrom<StackGameCreateResolver>());

			// List
            CreateMap<List, ListDto>();

            CreateMap<ListUpdateDto, List>()
                .ForMember(dest => dest.Games, opt => opt.MapFrom<ListGameUpdateResolver>());

            CreateMap<ListCreateDto, List>()
                .ForMember(dest => dest.Games, opt => opt.MapFrom<ListGameCreateResolver>());

            // Review
            CreateMap<Review, ReviewDto>()
                .ReverseMap();

            // PlayTime
            CreateMap<PlayTime, PlayTimeDto>()
                .ReverseMap();

            // Platform
            CreateMap<Platform, PlatformDto>();
        }
    }
}
