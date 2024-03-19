namespace Championship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(CampionshipDB db  = new CampionshipDB())
            {
                Team t1 = new Team()
                {
                    Name = "Real",
                    City = "Madrid",
                    Wins = 3,
                    Lose = 1,
                    Draw = 5
                };


                Team t2 = new Team()
                {
                    Name = "Barcelona",
                    City = "Barcelona",
                    Wins = 1,
                    Lose = 3,
                    Draw = 2
                };

                db.Teams.AddRange(t1, t2);
                db.SaveChanges();

                var teams = db.Teams;
                foreach (Team t in db.Teams)
                {
                    Console.WriteLine($"{t.Name} {t.City} {t.Wins} {t.Lose} {t.Draw}");
                }
            }
        }
    }
}
