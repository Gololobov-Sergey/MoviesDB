using Dapper;
using Microsoft.Data.SqlClient;
using Student_Dapper.Models;
using System.Data;

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
                    //string sql = "SELECT * FROM Students WHERE Id = @Id";
                    //int id  = Convert.ToInt32(Console.ReadLine());
                    //object param =  new { Id = id } ;
                    //var student = connection.QuerySingle<Student>(sql, param);
                    //Console.WriteLine(student);
                }


                {
                    //string sql = "SELECT * " +
                    //             "FROM Students " +
                    //             "JOIN Groups ON Students.GroupId = Groups.Id";

                    //var students = connection.Query<Student, Group, Student>(sql,
                    //    (s, g) =>
                    //    {
                    //        s.Group = g;
                    //        return s;
                    //    },
                    //    splitOn: "Id" );

                    //foreach ( var s in students )
                    //{
                    //    Console.WriteLine($"{s.Id} {s.Name} {s.BirthDay.ToShortDateString()} {s.Group!.Name}");
                    //}

                }


                {
                    //string sql = "SELECT * " +
                    //             "FROM Students " +
                    //             "JOIN Groups ON Students.GroupId = Groups.Id " +
                    //             "JOIN Curators ON Groups.CuratorId = Curators.Id";

                    //var students = connection.Query<Student, Group, Curator, Student>(sql,
                    //    (s, g, c) =>
                    //    {
                    //        g.Curator = c;
                    //        s.Group = g;
                    //        return s;
                    //    },
                    //    splitOn: "Id");

                    //foreach (var s in students)
                    //{
                    //    Console.WriteLine($"{s.Id} {s.Name} {s.BirthDay.ToShortDateString()} {s.Group!.Name} {s.Group!.Curator!.Name}");
                    //}

                }

                {
                    //string sql = "SELECT S.Name AS N, S.BirthDay AS BD, G.Name AS GN " +
                    //             "FROM Students AS S JOIN Groups AS G ON S.GroupId = G.Id";

                    //var students = connection.Query(sql);

                    //foreach (var s in students)
                    //{
                    //    Console.WriteLine($"{s.N} {(Convert.ToDateTime(s.BD)).ToShortDateString()} {s.GN}");
                    //}
                }

                {
                    string sql = "SELECT S.Name AS N, S.BirthDay AS BD, G.Name AS GN " +
                                 "FROM Students AS S JOIN Groups AS G ON S.GroupId = G.Id";

                    var reader = connection.ExecuteReader(sql);

                    DataTable table = new DataTable();
                    table.Load(reader);

                    foreach (DataRow row in table.Rows)
                    {
                        Console.WriteLine($"{row[0]} {row[1]} {row[2]}");
                    }
                }

            }
        }
    }
}
