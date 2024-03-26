using Dapper;
using Microsoft.Data.SqlClient;
using Student_Dapper.Models;

namespace Student_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                "Data Source=TAURUS\\SQLEXPRESS;" +
                "Initial Catalog=StudentsDB;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=False;" +
                "Trust Server Certificate=False;" +
                "Application Intent=ReadWrite;" +
                "Multi Subnet Failover=False";

            using (var connection = new SqlConnection(connectionString))
            {
                {
                    //string sql = "SELECT * FROM Students";

                    //var students = connection.Query<Student>(sql);

                    //foreach (var s in students)
                    //{
                    //    Console.WriteLine(s);
                    //}
                }


                {
                    //string insertStudent = "INSERT INTO " +
                    //    "Students (Name, BirthDay, GroupId, AddressId) " +
                    //    "VALUES (@Name, @BD, @GrId, @AddrId)";

                    //object[] param = 
                    //    { new { 
                    //        Name = "Jonh",
                    //        BD = "2000-02-15",
                    //        GrId = 1, 
                    //        AddrId = 1 
                    //    } };

                    //int rows = connection.Execute(insertStudent, param);

                    //Console.WriteLine($"Added {rows} rows");
                }


                {
                    //string updateStudent = "UPDATE Students SET GroupId = 3 WHERE Id = 5";

                    //int rows = connection.Execute(updateStudent);

                    //Console.WriteLine($"Added {rows} rows");
                }


                {
                    //string sql = "SELECT COUNT(*) FROM Students";
                    
                    //var count = connection.ExecuteScalar<int>(sql);

                    //Console.WriteLine(count);
                }


                {
                    string sql = "SELECT * FROM Students WHERE Id = @Id";
                    int id  = Convert.ToInt32(Console.ReadLine());
                    object param =  new { Id = id } ;
                    var student = connection.QuerySingle<Student>(sql, param);
                    Console.WriteLine(student);
                }
            }
        }
    }
}
