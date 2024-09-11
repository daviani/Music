using Microsoft.EntityFrameworkCore;
using MusicApi;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Writers;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
        .SetBasePath(builder.Environment.ContentRootPath)
        .AddJsonFile("appsettings.Development.json")
        .Build()
    ;
builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.AddDbContextPool<MusicDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("MusicDbConnection"));
    options.EnableSensitiveDataLogging(); 
    options.LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors (options => {
    options.AddPolicy ("AllowAll", builder => {
        builder.AllowAnyOrigin ()
            .AllowAnyMethod ()
            .AllowAnyHeader ();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MusicDbContext>();
    try
    {
        dbContext.Database.EnsureCreated();
        
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Connexion à la base de données MUSIC réussie.");

    }
    catch (Exception e)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, "Erreur lors de la connexion à la base de données MUSIC.");

        Console.WriteLine(e);
        throw;
    }
}

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