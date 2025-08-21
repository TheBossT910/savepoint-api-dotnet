using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using savepoint_api_dotnet.Data;
using System;
using System.Reflection;

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
