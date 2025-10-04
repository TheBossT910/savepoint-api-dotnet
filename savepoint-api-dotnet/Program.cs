using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Mapping;
using savepoint_api_dotnet.Services;
using savepoint_api_dotnet.Services.Apis;
using System.Reflection;

var _clientId = "";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SavePoint API",
        Description = "The ASP.NET Core Web API for SavePoint",
        Contact = new OpenApiContact
        {
            Name = "SavePoint Web GitHub",
            Url = new Uri("https://github.com/TheBossT910/savepoint-web")
        },
        License = new OpenApiLicense
        {
            Name = "© 2025 Taha Rashid ",
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Add EF Core + PostgreSQL database
builder.Services.AddDbContext<SavePointDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Allow CORS for the frontend
var allowedOrgin = "FrontendPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowedOrgin, policy =>
    {
        policy.WithOrigins("http://0.0.0.0:3000", "http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Adding mappers
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

// Adding resolvers
// TODO: rename resolvers with prefix 'Game' to be more specific
builder.Services.AddScoped<DeveloperCreateResolver>();
builder.Services.AddScoped<DeveloperUpdateResolver>();
builder.Services.AddScoped<GenreCreateResolver>();
builder.Services.AddScoped<GenreUpdateResolver>();
builder.Services.AddScoped<CategoryCreateResolver>();
builder.Services.AddScoped<CategoryUpdateResolver>();
builder.Services.AddScoped<ImageUpdateResolver>();
builder.Services.AddScoped<VideoUpdateResolver>();
builder.Services.AddScoped<GameVariationCreateResolver>();
builder.Services.AddScoped<GameVariationUpdateResolver>();
// Stack resolvers
builder.Services.AddScoped<StackGameCreateResolver>();
builder.Services.AddScoped<StackGameUpdateResolver>();
// List resolvers
builder.Services.AddScoped<ListGameCreateResolver>();
builder.Services.AddScoped<ListGameUpdateResolver>();
// Review resolvers
builder.Services.AddScoped<ReviewUpdateResolver>();
// Platform resolvers
builder.Services.AddScoped<PlatformCreateResolver>();
builder.Services.AddScoped<PlatformUpdateResolver>();

// Adding other services
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<StackService>();
builder.Services.AddScoped<ListService>();
builder.Services.AddScoped<GamesIGDBApiService>();

builder.WebHost.UseUrls("http://0.0.0.0:5000");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowedOrgin);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();