using GameStore.API.Data;
using GameStore.API.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder
            .WithOrigins("http://localhost:5173") // React app URL
            .AllowAnyMethod()
            .AllowAnyHeader().SetIsOriginAllowed(_ => true));
});

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<GameStoreContext>(options => options.UseSqlite(connectionString));
var connStr = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connStr);
var app = builder.Build();

app.UseCors("AllowReactApp");


app.MapGamesEndpoints();
app.MapGenresEndpoints();

await app.MigrateDbAsync();

app.Run();