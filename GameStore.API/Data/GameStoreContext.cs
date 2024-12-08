using GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) 
    : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Genre>().HasData(
           new  { Id = 1, Name = "RPG" },
           new  { Id = 2, Name = "FPS" },
           new  { Id = 3, Name = "MMO" },
           new  { Id = 4, Name = "MOBA" },
           new  { Id = 5, Name = "Racing" },
           new  { Id = 6, Name = "Simulation" },
           new  { Id = 7, Name = "Strategy" },
           new  { Id = 8, Name = "Sports" },
           new  { Id = 9, Name = "Adventure" },
           new  { Id = 10, Name = "Action" }
           
           
           );
    }
    
}