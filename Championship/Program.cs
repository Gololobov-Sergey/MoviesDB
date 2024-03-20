using Microsoft.EntityFrameworkCore;

namespace Championship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ChampionshipDB db = new ChampionshipDB())
            {

                //for (int i = 0; i < 20; i++)
                //{
                //    db.Players.Add(new Player()
                //    {
                //        Name = $"Player - Team {i / 5 + 1}",
                //        Number = i + 1,
                //        Position = "Forward",
                //        TeamId = i / 5 + 1
                //    });
                //}

                //db.SaveChanges();

                //var player = db.Players
                //    .Include(t => t.Team)
                //    .ToList();
                //foreach (Player p in db.Players)
                //{
                //    Console.WriteLine(p);
                //}


                var games = db.Games
                    .Include(t => t.Team1)
                    .Include(t => t.Team2)
                    .Where(t => t.Team1!.Name == "Valencia" 
                    || t.Team2!.Name == "Valencia");

                var gg = db.Games.Include(g=>g.Team1)
                    .Where(t=> t.TeamId1 == 1).ToList();

                foreach (var game in gg)
                {
                    Console.WriteLine($"{game}");
                }

            }
        }
    }
}
