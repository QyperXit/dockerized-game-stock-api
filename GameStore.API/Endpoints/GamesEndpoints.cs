using GameStore.API.Data;
using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints;

public static class GamesEndpoints
{
    
   // private static readonly List<GameSummaryDto> games =
   //  [
   //      new 
   //      (
   //          1,
   //          "Call of Duty: Modern Warfare",
   //          "First-Person Shooter",
   //          59.99m,
   //          new DateOnly(2019, 10, 25)
   //      ),
   //      new 
   //      (
   //          2,
   //          "Halo 3",
   //          "First-Person Shooter",
   //          49.99m,
   //          new DateOnly(2007, 9, 25)
   //      ),
   //      new 
   //      (
   //          3,
   //          "Counter-Strike: Global Offensive",
   //          "First-Person Shooter",
   //          19.99m,
   //          new DateOnly(2012, 8, 21)
   //      )
   //  ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games").WithParameterValidation();
        
        // GET /games
        group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Games.
            Include(game => game.Genre).Select(game => game.ToGameSummaryDto())
            .AsNoTracking().ToListAsync());

        //GET games/1
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) => 
        {

            Game? game = await dbContext.Games.FindAsync(id);
            
            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDtoDto());
        });
        
        
        //POST games
        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();
            
            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();
            
           return Results.Created($"/{game.Id}", game.ToGameDetailsDtoDto());
        });
        
        // PUT games
        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            
            var existingGame = await dbContext.Games.FindAsync(id);
            if ( existingGame is null )
            {
                return Results.NotFound();
            }
            
            dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));
             await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE games
        group.MapDelete("/{id}", async (int id,GameStoreContext dbContext) =>
        {
            await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
            // var index = games.FindIndex(g => g.Id == id);
            // games.RemoveAt(index);
            return Results.NoContent();
        });

        return group;

    }
    
}