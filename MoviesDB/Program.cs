namespace MoviesDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (MoviesContext db = new MoviesContext())
            {
                //var directors = db.Directors.ToList();
                var directors = db.Directors
                    .Where(d => d.BirthDay.Day == 10)
                    .ToList();
                Console.WriteLine("Directors");
                Console.WriteLine("==========================");
                foreach (var director in directors)
                {
                    Console.WriteLine(director);
                }
            }

            //using (MoviesContext db = new MoviesContext())
            //{
            //    Console.Write("FirstName: ");
            //    string fn = Console.ReadLine();
            //    Console.Write("FirstName: ");
            //    string ln = Console.ReadLine();
            //    Console.Write("Date B: ");
            //    DateOnly d = DateOnly.FromDateTime(Convert.ToDateTime(Console.ReadLine()));

            //    Director director = new Director()
            //    {
            //        FirsName = fn,
            //        LastName = ln,
            //        BirthDay = d
            //    };

            //    db.Directors.Add(director);
            //    db.SaveChanges();
            //}

            //using (MoviesContext db = new MoviesContext())
            //{
            //    Director? director = 
            //        db.Directors.Where(d => d.LastName == "Spilberg").
            //        FirstOrDefault();

            //    if(director != null)
            //    {
            //        director.BirthDay = new DateOnly(1960, 10, 10);
            //        db.SaveChanges();
            //    }

            //}

            //using (MoviesContext db = new MoviesContext())
            //{
            //    Director? director =
            //        db.Directors.Where(d => d.Id == 4).
            //        FirstOrDefault();
            //    if (director != null)
            //    {
            //        db.Directors.Remove(director);
            //        db.SaveChanges();
            //    }
            //}
        }
    }
}
