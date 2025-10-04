//using System;
using AutoMapper;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Models.Api;
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

            // GameIGDB to Game
            // TODO: make resolvers for developers, genres, images, videos, platforms, reviews to avoid duplicates
            // TODO: make custom resolver for splash to pick best image
            CreateMap<GameIGDB, Game>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Dtc, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Cover, opt => opt.MapFrom(src => src.Cover != null ? src.Cover.Url : null))
                .ForMember(dest => dest.Developers, opt => opt.MapFrom(src => src.InvolvedCompanies != null ? src.InvolvedCompanies.ConvertAll(ic => new Developer { Id = 0, Name = ic.Company.Name }) : new List<Developer>()))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres != null ? src.Genres.ConvertAll(g => new Genre { Id = 0, Name = g.Name }) : new List<Genre>()))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images != null ? src.Images.ConvertAll(i => new Image { Id = 0, Url = i.Url, Source = "IGDB" }) : new List<Image>()))
                .ForMember(dest => dest.Videos, opt => opt.MapFrom(src => src.Videos != null ? src.Videos.ConvertAll(v => new Video { Id = 0, Url = v.Url, Source = "IGDB" }) : new List<Video>()))
                .ForMember(dest => dest.Splash, opt => opt.Ignore())
                // TODO: add platforms
                .ForMember(dest => dest.Platforms, opt => opt.MapFrom(src => src.Platforms != null ? src.Platforms.ConvertAll(p => new Platform { Id = 0, PlatformLogo = p.PlatformLogo.Url, Hardware = p.Platform }) : new List<Platform>()))
                // TODO: add aggregated rating as review
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.AggregatedRating > 0 ? new List<Review> { new Review { Id = 0, Source = "IGDB", Rating = Math.Round(src.AggregatedRating).ToString(), Url = src.Websites != null && src.Websites.Count > 0 ? src.Websites[0].Url : null } } : new List<Review>()));


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
