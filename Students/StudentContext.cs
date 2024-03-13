using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class StudentContext : DbContext
    {
        public StudentContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Group> Groups { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=TAURUS\\SQLEXPRESS;Initial Catalog=StudentsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Group>();

            //modelBuilder.Entity<Student>().Ignore(s => s.LastName);

            //modelBuilder.Entity<Student>().Property(s => s.BirthDay).HasColumnName("bd");

            //modelBuilder.Entity<Student>().ToTable("User");

            //modelBuilder.Entity<Student>().Property(s => s.Name).IsRequired();

            //modelBuilder.Entity<Student>().Property(p => p.Name).HasDefaultValue("Serg");

            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "PV321"},
                new Group { Id = 2, Name = "PV111"},
                new Group { Id = 3, Name = "P-320"}
                );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Serg", BirthDay = new DateOnly(2000, 10, 12), GroupId = 1},
                new Student { Id = 2, Name = "Anna", BirthDay = new DateOnly(1999, 02, 01), GroupId = 2},
                new Student { Id = 3, Name = "Olga", BirthDay = new DateOnly(1999, 05, 05), GroupId = 1},
                new Student { Id = 4, Name = "Oleg", BirthDay = new DateOnly(2001, 08, 20), GroupId = 3}
                );
        }


        

    }
}
