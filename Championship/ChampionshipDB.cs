using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Championship
{
    public class ChampionshipDB : DbContext
    {
        public List<TournamentTable> TournamentTable = [];
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Goal> Goals { get; set; } = null!;

        public IQueryable<Team> GetTeams(string city)
        {
            return FromExpression(() => GetTeams(city));
        }

        public ChampionshipDB() 
        { 
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=TAURUS\\SQLEXPRESS;Initial Catalog=ChampionshipDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(() => GetTeams(default));

            //modelBuilder.HasDbFunction(typeof(ChampionshipDB).GetMethod(nameof(GetTeam), null));

            modelBuilder.Entity<Team>().HasData(
            new Team()
            {
                Id = 1,
                Name = "Atletico",
                City = "Madrid"
            },

            new Team()
            {
                Id = 2,
                Name = "Valencia",
                City = "Valencia"
            }
            );
        }
    }
}
