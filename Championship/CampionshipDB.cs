using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Championship
{
    public class CampionshipDB : DbContext
    {
        public DbSet<Team> Teams { get; set; } = null!;

        public CampionshipDB() 
        { 
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=TAURUS\\SQLEXPRESS;Initial Catalog=CampionshipDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Team>().HasData(
            new Team()
            {
                Id = 1,
                Name = "Atletico",
                City = "Madrid",
                Wins = 3,
                Lose = 1,
                Draw = 5
            },

            new Team()
            {
                Id = 2,
                Name = "Valencia",
                City = "Valencia",
                Wins = 1,
                Lose = 3,
                Draw = 2
            }
            );
        }
    }
}
