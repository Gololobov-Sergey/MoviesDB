using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region SelectStudent
            //using(StudentContext db =  new StudentContext())
            //{
            //    var students = db.Students
            //        .Include(s=>s.Group).ToList();

            //    //var groups = db.Groups.ToList();

            //    foreach (var student in students)
            //    {
            //        Console.WriteLine(student + ", Group: " + student.Group?.Name);
            //    }
            //}
            #endregion


            #region SelectSubject
            //using (StudentContext db = new StudentContext())
            //{
            //    var students = db.Students
            //        .Include(s => s.Subjects).ToList();

            //var groups = db.Groups.ToList();

            //foreach (var student in students)
            //{
            //    Console.Write(student + ", Group: " + student.Group?.Name);
            //    Console.Write(", Subjects: ");
            //    foreach (var subj in student.Subjects)
            //    {
            //        Console.Write(subj.Name + ", ");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine("=================================");
            //var subjects = db.Subjects.Include(s=> s.Students).ToList();
            //foreach(var subject in subjects)
            //{
            //    Console.Write(subject.Name);
            //    Console.Write(": ");
            //    foreach (var stud in subject.Students)
            //    {
            //        Console.Write(stud.Name +", ");
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            //using (StudentContext db = new StudentContext())
            //{

            //    var st = db.Students
            //        .Include(s => s.Group)
            //         //   .ThenInclude(g => g.Curator)
            //         .Include(g => g.Group!.Curator)
            //        .ToList();

            //    foreach (Student s in st)
            //    {
            //        Console.WriteLine($"{s.Name} ");
            //        /*{s.Group!.Name} {s.Group!.Curator!.Name}*/
            //    }
            //}


            using (StudentContext db = new StudentContext())
            {

               var student = db.Students
                    .Include(s=>s.Exam)
                        .ThenInclude(e=>e.Subject)
                    .ToList();

                foreach (var s in student)
                {
                    Console.WriteLine($"{s.Name}");
                    foreach (var e in s.Exam)
                    {
                        Console.Write($"{e.Subject.Name} {e.Mark}, ");
                    }
                    Console.WriteLine();
                }

                SqlParameter param = new SqlParameter("@param", "%a%");
                var st = db.Students
                    .FromSqlRaw("select * from students where name like @param", param).ToList();
                foreach(var s in st)
                {
                    Console.WriteLine(s);
                }
            }





        }
    }
}
