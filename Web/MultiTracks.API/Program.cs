using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MultiTracks.API.Domain.Core.Mapping;
using MultiTracks.API.Domain.Core.Services;
using MultiTracks.API.Domain.Core.Services.IService;
using MultiTracks.API.Domain.Models;
using MultiTracks.API.Infrastructure;
using MultiTracks.API.Infrastructure.IRepositories;
using MultiTracks.API.Infrastructure.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<ISongService, SongService>();

builder.Services.AddAutoMapper(typeof(Mapping));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Exception handling
app.UseExceptionHandler(error =>
{
    error.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature is not null)
        {
            Log.Error($"Something went wrong in the {contextFeature.Error}");
            await context.Response.WriteAsync(new Error
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error. Please Try Again Later.",

            }.ToString());
        }
    });
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
