namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(StudentContext db =  new StudentContext())
            {
                var students = db.Students.ToList();
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
