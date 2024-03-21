using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

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


                //var games = db.Games
                //    .Include(t => t.Team1)
                //    .Include(t => t.Team2)
                //    .Include(g => g.Goals)
                //    .Where(t => t.Team1!.Name == "Valencia" 
                //    || t.Team2!.Name == "Valencia");

                //var gg = db.Games
                //    .Include(g => g.Team1)
                //    .Include(g => g.Team2)
                //    .Include(g => g.Goals)
                //    .ToList();

                //foreach (var game in gg)
                //{
                //    int g1 = game.Goals.Count(g => game.TeamId1 == g.TeamId);
                //    int g2 = game.Goals.Count(g => game.TeamId2 == g.TeamId);
                //    Console.WriteLine($"{game} {g1} {g2}");
                //}

                //var teams = db.Teams.ToList();

                //foreach (var team in teams)
                //{
                //    var gameTeams = db.Games
                //        .Include(g => g.Team1)
                //        .Include(g => g.Team2)
                //        .Include(g => g.Goals)
                //        .Where(t => t.Team1 == team || t.Team2 == team)
                //        .ToList();

                //    Console.WriteLine(team.Name);

                //    int winGoals = 0, loseGoals = 0, win = 0, lose = 0, draw = 0;

                //    foreach (var game in gameTeams)
                //    {
                //        int g1 = game.Goals.Count(g => game.TeamId1 == g.TeamId);
                //        int g2 = game.Goals.Count(g => game.TeamId2 == g.TeamId);
                //        Console.WriteLine($"{game} {g1} {g2}");

                //        if(team.Id == game.TeamId1)
                //        {
                //            winGoals += g1;
                //            loseGoals += g2;
                //            if(g1 > g2)
                //            {
                //                win++;
                //            }
                //            else if(g1 < g2)
                //            {
                //                lose++;
                //            }
                //            else
                //            {
                //                draw++;
                //            }
                //        }
                //        else
                //        {
                //            winGoals += g2;
                //            loseGoals += g1;
                //            if (g1 < g2)
                //            {
                //                win++;
                //            }
                //            else if (g1 > g2)
                //            {
                //                lose++;
                //            }
                //            else
                //            {
                //                draw++;
                //            }
                //        }
                //    }

                //    db.TournamentTable.Add(new TournamentTable()
                //    {
                //        Name = team.Name!,
                //        WinGoal = winGoals,
                //        LoseGoal = loseGoals,
                //        Wins = win,
                //        Lose = lose,
                //        Draw = draw,
                //        Score = win * 3 + draw
                //    });
                //}
                //Console.WriteLine("---------------------------------------------");
                //Console.WriteLine($"{"Name".PadRight(10)} |  WG |  LG |  W  |  D  |  L  |  S  ");
                //Console.WriteLine("---------------------------------------------");
                //db.TournamentTable.Sort((t1, t2) => t2.Score.CompareTo(t1.Score));
                //foreach (var item in db.TournamentTable)
                //{
                //    Console.WriteLine(item);
                //}



                var st = db.GetTeams("Madrid").ToList();
                foreach (Team t in st)
                {
                    Console.WriteLine(t.Name);
                }

            }
        }
    }
}
