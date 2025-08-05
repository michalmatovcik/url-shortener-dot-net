using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Application;
using UrlShortener.Application.Commands;
using UrlShortener.Application.Queries;
using UrlShortener.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICacheService, RedisCacheService>();
builder.Services.AddScoped<IUrlRepository, UrlRepository>();
builder.Services.AddDbContext<UrlDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MediatR for CQRS pattern
builder.Services.AddMediatR(typeof(Program).Assembly);

// Register command and query handlers...
builder.Services.AddScoped<IRequestHandler<ShortenUrlCommand, string>, ShortenUrlHandler>(); //CR - MediatR si registruje handlery sam cez reflexiu, netreba to explicitne pisat
builder.Services.AddScoped<IRequestHandler<ResolveUrlQuery, string>, ResolveUrlHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "UrlShortener API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at root
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();