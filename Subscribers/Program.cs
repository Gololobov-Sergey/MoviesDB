using Dapper;
using Microsoft.Data.SqlClient;
using Subscribers.Model;
using Z.Dapper.Plus;
using HtmlAgilityPack;
using System.Data;
using System.Collections.Generic;


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
                string sql = "SELECT * FROM Subscriber WHERE Id = (SELECT Id FROM Country WHERE Name = @Name)";
                return connection.Query<Subscriber>(sql, new {Name = country});
            }
        }

        static IEnumerable<Product> GetSpecialProductFromDate(string category, DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Product AS P" +
                             "JOIN SpecialOfer AS SO ON P.SpecialOferId = SO.Id" +
                              "WHERE P.CategoryId = " +
                                 "(SELECT Id FROM Category WHERE Name = @Category) " +
                              " AND ('@Date' BETWEEN SO.DateStart AND SO.DateEnd)";

                return connection.Query<Product>(sql, new { Category = category, Date = date.ToShortDateString() });
            }
        }

        static void Main(string[] args)
        {

            //var subs = GetSubscriberFromCountry("Country 1");
            //foreach (Subscriber s in subs)
            //{
            //    Console.WriteLine($"{s.Id} {s.Name} {s.BirthDay.ToShortDateString()} {s.Email}");
            //}


            var products = GetSpecialProductFromDate("Category 1", new DateTime(2024, 03, 28));
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name}");
            }

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
