using Dapper;
using Microsoft.Data.SqlClient;
using Subscribers.Model;
using Z.Dapper.Plus;
using System.Collections.Generic;
using System.Data;




namespace Subscribers
{
    internal class Program
    {

        static string connectionString =
                "Data Source=TAURUS\\SQLEXPRESS;" +
                "Initial Catalog=Subscribers;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=False;" +
                "Trust Server Certificate=False;" +
                "Application Intent=ReadWrite;" +
                "Multi Subnet Failover=False";
        static IEnumerable<Subscriber> GetSubscriberFromCountry(string country)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Subscriber WHERE CountryId = (SELECT Id FROM Country WHERE Name = @Name)";
                return connection.Query<Subscriber>(sql, new {Name = country});
            }
        }

        static DataTable GetSubscrFromCountry(string country)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT S.Name AS SubsName, S.Email, S.Gender, C.Name " +
                    "FROM Subscriber AS S " +
                    "JOIN Country AS C ON C.Id = S.CountryId " +
                    "WHERE CountryId = (SELECT Id FROM Country WHERE Name = @Name)";
                var reader = connection.ExecuteReader(sql, new { Name = country });
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            }
        }

        static DataTable GetCountSubscrFromCountry()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT C.Name AS 'Country', COUNT(S.CountryId) AS 'Count' " +
                    "FROM Subscriber AS S JOIN Country AS C ON S.CountryId = C.Id " +
                    "GROUP BY C.Name ORDER BY 2 DESC";
                var reader = connection.ExecuteReader(sql);
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            }
        }

        static IEnumerable<Product> GetSpecialProductFromDate(string category, DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Product AS P " +
                    "JOIN SpecialOfer AS SO ON P.SpecialOferId = SO.Id " +
                    "WHERE P.CategoryId = (SELECT Id FROM Category WHERE Name = @Category) " +
                    "AND (@Date BETWEEN SO.DateStart AND SO.DateEnd)";

                return connection.Query<Product>(sql, new { Category = category, Date = date.ToString("yyyy-MM-dd") });
            }
        }

        static void Main(string[] args)
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    var list = new List<Subscriber>();
            //    list.Add(new Subscriber() { Name = "Alice", BirthDay = new DateTime(1990, 5, 15), Gender = false, Email = "alice@example.com", CountryId = 1 });
            //    list.Add(new Subscriber() { Name = "Bob", BirthDay = new DateTime(1985, 10, 25), Gender = true, Email = "bob@example.com", CountryId = 2 });
            //    list.Add(new Subscriber() { Name = "Charlie", BirthDay = new DateTime(1988, 3, 8), Gender = true, Email = "charlie@example.com", CountryId = 3 });
            //    list.Add(new Subscriber() { Name = "David", BirthDay = new DateTime(1995, 7, 12), Gender = true, Email = "david@example.com", CountryId = 1 });
            //    list.Add(new Subscriber() { Name = "Eve", BirthDay = new DateTime(1992, 9, 20), Gender = false, Email = "eve@example.com", CountryId = 2 });
            //    list.Add(new Subscriber() { Name = "Frank", BirthDay = new DateTime(1983, 12, 30), Gender = true, Email = "frank@example.com", CountryId = 3 });
            //    list.Add(new Subscriber() { Name = "Grace", BirthDay = new DateTime(1998, 2, 5), Gender = false, Email = "grace@example.com", CountryId = 1 });
            //    list.Add(new Subscriber() { Name = "Henry", BirthDay = new DateTime(1980, 6, 18), Gender = true, Email = "henry@example.com", CountryId = 2 });
            //    list.Add(new Subscriber() { Name = "Ivy", BirthDay = new DateTime(1993, 11, 10), Gender = false, Email = "ivy@example.com", CountryId = 3 });
            //    list.Add(new Subscriber() { Name = "Jack", BirthDay = new DateTime(1987, 4, 22), Gender = true, Email = "jack@example.com", CountryId = 1 });

            //    connection.BulkInsert(list);
            //}

            //var subs = GetSubscriberFromCountry("Country 1");
            //foreach (Subscriber s in subs)
            //{
            //    Console.WriteLine($"{s.Id} {s.Name} {s.BirthDay.ToShortDateString()} {s.Email}");
            //}


            //var products = GetSpecialProductFromDate("Category 2", new DateTime(2024, 03, 28));

            //foreach (var p in products)
            //{
            //    Console.WriteLine($"{p.Name}");
            //}

            //var products = GetSubscrFromCountry("Country 1");
            //products.PrintList((obj, row, column) =>
            //{
            //    if (obj == DBNull.Value)
            //        return null;

            //    if (column.ColumnName == "Gender")
            //    {
            //        return (bool)obj ? "M" : "F";
            //    }

            //    if (column.ColumnName == "BirthDay")
            //        return ((DateTime)obj).ToShortDateString();

            //    return obj.ToString();
            //});


            var table = GetCountSubscrFromCountry();
            table.Print();

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    //connection.CreateTable<Category>();
            //    //connection.CreateTable<Country>();
            //    //connection.CreateTable<Product>();
            //    //connection.CreateTable<SpecialOffer>();
            //    //connection.CreateTable<Subscriber>();
            //    //connection.CreateTable<WishList>();


            //    //var outputCategories = connection
            //    //    .Query<Category>("SELECT * FROM Category").ToList();
            //    //Console.WriteLine("Categories:");

            //    //foreach (var c in outputCategories) 
            //    //{
            //    //    Console.WriteLine($"{c.Id} {c.Name}");
            //    //}



            //    var outputProduct = connection
            //        .Query<Category>("SELECT * FROM Product WHERE SpecialOferId IS NOT NULL").ToList();
            //    Console.WriteLine("Categories:");

            //    foreach (var c in outputProduct)
            //    {
            //        Console.WriteLine($"{c.Id} {c.Name}");
            //    }

            //}
        }
    }
}
